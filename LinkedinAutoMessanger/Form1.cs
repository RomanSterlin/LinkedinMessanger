using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using Keys = OpenQA.Selenium.Keys;

namespace LinkedinAutoMessanger
{
    public partial class Form1 : Form
    {
        private Thread t2;
        private Thread t3;
        private Thread discardThread;
        private Thread removeConnection;
        private Thread sendConnections;
        private IWebDriver driver;
        private string msg = string.Empty;
        private string tempMsg { get; set; }
        private string CurrentName { get; set; }
        private String TrimmedName { get; set; }
        public bool Block = false;

        private bool Loaded = false;
        DataAccess access = new DataAccess();
        public Form1()
        {
            InitializeComponent();
           
        }

        //This is the program that Sends messages to users.
        public void MessageSender()
        {

            driver = new ChromeDriver();
            t3 = new Thread(MessageDialogCloser);
            t3.Start();
            discardThread = new Thread(DiscardMessageThread);
            discardThread.Start();
            string url2 = string.Empty;
            if (InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    url2 = searchLinkInput.Text;

                    msg = messageInput.Text;
                }));

            }
            int i = 0;

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement element;
            InputSimulator input = new InputSimulator();
            string url1 = "https://www.linkedin.com/uas/login?session_redirect=%2Fvoyager%2FloginRedirect%2Ehtml&fromSignIn=true&trk=uno-reg-join-sign-in";

            // Login
            driver.Navigate().GoToUrl(url1);
            driver.FindElement(By.CssSelector("input#username")).SendKeys(usernameInput.Text);
            driver.FindElement(By.CssSelector("input#password")).SendKeys(passwordInput.Text);
            driver.FindElement(By.XPath("//*[@id=\"app__container\"]/main/div/form/div[3]/button")).Click();
            Thread.Sleep(1000);

            driver.Navigate().GoToUrl(url2);
            Thread.Sleep(5000);
            //Go to the bottom of the page to get full HTML.
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
            Thread.Sleep(200);
            //check if next button is enabled.
            while (driver.FindElement(By.ClassName("artdeco-pagination__button--next")).Enabled)
            {
                var elements = driver.FindElements(By.ClassName("search-result__wrapper"));
                foreach (var ele in elements)
                {
                    if (ele.FindElement(By.ClassName("subline-level-1")).GetAttribute("innerHTML").Contains("HR"))
                    {

                        Thread.Sleep(1000);
                        js.ExecuteScript("arguments[0].scrollIntoView()", ele);
                        CurrentName = string.Empty;
                        ele.FindElement(By.ClassName("message-anywhere-button")).SendKeys(Keys.Return);

                        //this has to wait for the message to load, while this happens another message could open 
                        Thread.Sleep(2000);
                        try
                        {
                            /*Check for this class, this class is representing a message insid the message box, if its missing
                            an exception will be thrown meaning that there is no previous message and you can proceed and send one.
                            */
                            driver.FindElement(By.ClassName("msg-overlay-conversation-bubble--petite"));
                            //close window

                            Thread.Sleep(2000);

                            var name = driver.FindElement(By.ClassName("profile-card-one-to-one__profile-link")).GetAttribute("innerHTML");
                            TrimmedName = CheckAndRemoveSpecialChar(name);
                            CurrentName = TrimmedName;
                            ChangeUserName();
                            //check why did I use while instead of if
                            while (driver.FindElement(By.ClassName("msg-form__contenteditable")).Text == string.Empty)
                            {
                                input.Keyboard.TextEntry(tempMsg);
                            }
                            Thread.Sleep(2000);

                            //send mesage
                            element = driver.FindElement(By.CssSelector("li-icon[type='paperclip-icon'"));
                            element.Click();

                            Thread.Sleep(2000);
                            input.Keyboard.TextEntry("Roman Sterlin.pdf");
                            input.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                            Thread.Sleep(5000);
                            driver.FindElement(By.ClassName("msg-form__send-button")).Click();
                            i++;
                            if (InvokeRequired)
                            {
                                this.Invoke(new Action(() => counter.Text = i.ToString()));
                            }
                            Thread.Sleep(2000);
                            driver.FindElement(By.ClassName("js-msg-close")).Click();

                            try
                            {
                                driver.FindElement(By.ClassName("msg-modal-discard-message"));
                            }
                            catch (Exception exc)
                            {

                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                driver.FindElement(By.ClassName("artdeco-pagination__button--next")).Click();
                Thread.Sleep(2000);
            }
        }  
      
        //Start button grays out the start button, when pause is clicked it is changed into resume & vise versa.

        public void DiscardMessageThread() {
            while (true)
            {
                try
                {
                    var discard = driver.FindElement(By.ClassName("msg-modal-discard-message"));
                   var discards = discard.FindElements(By.ClassName("artdeco-button__text"));
                    foreach(var dis in discards)
                    {
                        if (dis.Text.Equals("Discard")) {
                            dis.Click();
                        }
                    }
                    Console.WriteLine("found discard");
                }
                catch (Exception ex) { }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (pause.Name == "pause")
                {
                    pause.Name = "resume";
                    pause.Text = "Resume";
                    t2.Suspend();
                    t3.Suspend();
                    sendConnections.Suspend();
                    removeConnection.Suspend();
                }
                else if (pause.Name == "resume")
                {
                    pause.Name = "pause";
                    pause.Text = "Pause";
                    t2.Resume();
                    t3.Resume();
                    sendConnections.Resume();
                    removeConnection.Resume();
                }
            }catch(Exception ex) { }
        }

        /* A thread that runs in the background that closes every message window that pops out that isn't the one currently open.
        stores all the current open windows in an Collection and iterates over them to check if they have a message body in them, those
        who have, close them.
            */
        public void MessageDialogCloser()
        {
            while (true) {
                
                    var conversations = driver.FindElements(By.ClassName("msg-overlay-conversation-bubble--petite"));
                    foreach(var conversation in conversations)
                    {
                    try
                    {
                        conversation.FindElement(By.ClassName("msg-s-event-listitem__body"));
                        conversation.FindElement(By.ClassName("js-msg-close")).Click();
                    }
                    catch(Exception exception) { }
                    }     
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //t2 is the message sender, t3 is the messagepopup closer.
            if (CheckUsernameInput())
            {
                start.Enabled = false;
                t2 = new Thread(MessageSender);
                t2.Start();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            driver.Quit();
            Environment.Exit(0);
        }

        //Removes special characters from username.
        public static String CheckAndRemoveSpecialChar(string name)
        {
            char[] specialChar = { '?' };
            String newName = name.Trim();
            if (newName.Contains("?"))
            {
                newName.Trim(specialChar);
            }
            return newName;
        }
      
        //If checkbox is checked, changes the "UserNameHere" to the users name.
        public void ChangeUserName() {
            if (checkBox1.Checked)
            {
                if (msg.Contains("UserNameHere"))
                {
                    tempMsg = msg.Replace("UserNameHere", TrimmedName);
                }
            }
        }

        //Checks that all required fileds are filled.
        public Boolean CheckUsernameInput() {

                if (usernameInput.Text == string.Empty || passwordInput.Text == string.Empty || searchLinkInput.Text == string.Empty)
                {
                    MessageBox.Show("Something is missing, please check fields");
                    return false;
                }

            return true;
        }

        private void SendConnections()
        {
            string url1 = "https://www.linkedin.com/uas/login?session_redirect=%2Fvoyager%2FloginRedirect%2Ehtml&fromSignIn=true&trk=uno-reg-join-sign-in";
            string url2 = "https://www.linkedin.com/search/results/people/?facetGeoRegion=%5B%22il%3A0%22%5D&facetNetwork=%5B%22S%22%2C%22O%22%5D&keywords=hr&origin=FACETED_SEARCH&page=25";
            IWebDriver driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            InputSimulator input = new InputSimulator();
            IWebElement sendButton;
            IWebElement stop = null;

            //Login

            driver.Navigate().GoToUrl(url1);
            driver.FindElement(By.CssSelector("input#username")).SendKeys(usernameInput.Text);
            driver.FindElement(By.CssSelector("input#password")).SendKeys(passwordInput.Text);
            driver.FindElement(By.XPath("//*[@id=\"app__container\"]/main/div/form/div[3]/button")).Click();
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl(url2);

            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 200)");

            Thread.Sleep(1000);
            var next = driver.FindElement(By.ClassName("artdeco-pagination__button--next"));

            //check if "next" button availble (checking if not last page)
            while (next.Enabled)
            {
                Thread.Sleep(1000);
                var elements = driver.FindElements(By.ClassName("search-result__wrapper"));
                foreach (var el in elements)
                {
                    try
                    {
                        var ele = el.FindElement(By.ClassName("search-result__action-button")).GetAttribute("innerHTML");
                        if (ele.Contains("Connect"))
                        {
                            //If user is not in data base, try to add him.
                            if (GetAllUsers(el.FindElement(By.ClassName("actor-name")).Text))
                            {
                                Thread.Sleep(1000);
                                js.ExecuteScript("arguments[0].scrollIntoView()", el);
                                Thread.Sleep(1000);
                                el.FindElement(By.ClassName("search-result__action-button")).SendKeys(Keys.Return);
                                Thread.Sleep(1000);
                                var buttons = driver.FindElements(By.ClassName("artdeco-button--3"));
                                foreach (var button in buttons)
                                {
                                    if (button.GetAttribute("innerHTML").Contains("Send"))
                                    {
                                        Thread.Sleep(1000);
                                        sendButton = button;
                                        if (sendButton.Enabled)
                                        {
                                            sendButton.Click();
                                            AddUser(el.FindElement(By.ClassName("actor-name")).Text);
                                        }
                                        else
                                        {
                                            driver.FindElement(By.ClassName("artdeco-modal__dismiss")).SendKeys(Keys.Return);
                                        }
                                        Thread.Sleep(1000);
                                        try
                                        {
                                            //Test if block popup is up, if so terminate driver, browser & program.
                                            stop = driver.FindElement(By.ClassName("ip-fuse-limit-alert__warning"));
                                        }
                                        catch (Exception ex) { }
                                        if (stop != null)
                                        {
                                            driver.Quit();
                                            Environment.Exit(0);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                Thread.Sleep(1000);
                next.SendKeys(Keys.Return);
                Thread.Sleep(1000);
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 200)");
            }
        }

        public void RemoveConnections() {
            string url1 = "https://www.linkedin.com/uas/login?session_redirect=%2Fvoyager%2FloginRedirect%2Ehtml&fromSignIn=true&trk=uno-reg-join-sign-in";
            string url2 = "https://www.linkedin.com/mynetwork/invite-connect/connections/";
            IWebDriver driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            InputSimulator input = new InputSimulator();
            IWebElement element;

            //Login

            driver.Navigate().GoToUrl(url1);
            driver.FindElement(By.CssSelector("input#username")).SendKeys(usernameInput.Text);
            driver.FindElement(By.CssSelector("input#password")).SendKeys(passwordInput.Text);
            driver.FindElement(By.XPath("//*[@id=\"app__container\"]/main/div/form/div[3]/button")).Click();
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl(url2);

            //Scroll down to load all the connections.
            while (!Loaded)
                try
                {
                    Thread.Sleep(5000);
                    ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 200)");
                    Thread.Sleep(50);
                    driver.FindElement(By.ClassName("artdeco-loader"));
                }
                catch (Exception exxx)
                {
                    Loaded = true;
                }

            var elements = driver.FindElements(By.ClassName("list-style-none"));
            foreach (var ele in elements)
            {
                if (ele.FindElement(By.ClassName("mn-connection-card__occupation")).Text.Contains("HR"))
                {
                    var Added = ele.FindElement(By.ClassName("time-badge")).Text;
                    if (Added.Contains("week") || Added.Contains("month") || Added.Contains("year"))
                    {
                        js.ExecuteScript("arguments[0].scrollIntoView()", ele);
                        ele.FindElement(By.ClassName("message-anywhere-button")).SendKeys(Keys.Return);
                        Thread.Sleep(2000);
                        try
                        {
                            driver.FindElement(By.ClassName("msg-s-event-listitem__body"));
                            Thread.Sleep(2000);
                            while (driver.FindElement(By.ClassName("msg-form__contenteditable")).Text == string.Empty)
                            {
                                input.Keyboard.TextEntry("Hi, because of Linkedin's limitations im removing alot of people from my connection list to make room for new HR's, If you read my message and you are removed but you like my resume, please message me so we could go forward! hope to talk to you soon! :) If we spoke, just ignore..! this is a bot.");
                            }
                            driver.FindElement(By.ClassName("msg-form__send-button")).Click();
                            Thread.Sleep(1000);
                            driver.FindElement(By.ClassName("js-msg-close")).Click();
                            Thread.Sleep(2000);
                            ele.FindElement(By.ClassName("mn-connection-card__dropdown-trigger")).SendKeys(Keys.Return);
                            Thread.Sleep(1000);

                            Thread.Sleep(1000);
                            ele.FindElement(By.ClassName("mn-connection-card__dropdown-option-text")).Click();
                            var buttons = driver.FindElements(By.ClassName("artdeco-button__text"));
                            foreach (var button in buttons)
                            {
                                if (button.Text.Contains("Remove"))
                                {
                                    button.Click();
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            Thread.Sleep(1000);
                            driver.FindElement(By.ClassName("js-msg-close")).SendKeys(Keys.Return);
                        }
                    }
                }
            }
        }
        //Compare current user with db users
        public Boolean GetAllUsers(string username)
        {
          var Users = access.GetAllUsers();
            foreach(var User in Users)
            {
                if (User.Equals(username))
                {
                    return false;
                }             
            }
            return true;
        }

        public void AddUser(string username)
        {
            access.AddUser(username);         
        }

        //This is the Connections request sender.
        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            sendConnections = new Thread(SendConnections);
            sendConnections.Start();
        }
        //Remove old connections, send messages incase they read after removed. Ignore none-HR, ignore people added less than a week ago.
        private void RemoveConnections_Click(object sender, EventArgs e)
        {
            removeConnection = new Thread(RemoveConnections);
            removeConnection.Start();
        }
    }
}
