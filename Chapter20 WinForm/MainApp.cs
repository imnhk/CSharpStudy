using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsTest
{
    #region Windows Test Code
    /*
    class MainApp : Form
    {
        static void Main(string[] args)
        {
            MainApp form = new MainApp();

            form.Click += new EventHandler((sender, eventArgs) =>
            {
                Console.WriteLine("Closing windows...");
                Application.Exit();
            });

            Console.WriteLine("Starting windows application...");
            Application.Run(form);

            Console.WriteLine("Exiting windows application...");
        }
    }*/
    #endregion

    #region MessageFilter
    /*
    class MessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x0fF || m.Msg == 0xA0 || m.Msg == 0x200 || m.Msg == 0x113)
                return false;

            Console.WriteLine($"{m.ToString()} : {m.Msg}");

            if (m.Msg == 0x201)
                Application.Exit();

            return true;
        }
    }

    class MainApp : Form
    {
        static void Main(string[] args)
        {
            Application.AddMessageFilter(new MessageFilter());
            Application.Run(new MainApp());
        }
    }
    */
    #endregion

    #region MouseEvent
    /*
class MainApp : Form
{
    public void MyMouseHandler(object sender, MouseEventArgs e)
    {
        Console.WriteLine("Sender : {0}", ((Form)sender).Text);
        Console.WriteLine($"[{e.X}, {e.Y}]");
        Console.WriteLine($"Button: {e.Button}, Clicks: {e.Clicks}");
        Console.WriteLine();
    }

    public MainApp(string title)
    {
        this.Text = title;
        this.MouseDown += new MouseEventHandler(MyMouseHandler);
    }

    static void Main(string[] args)
    {
        Application.Run(new MainApp("MouseEvent Test"));
    }
}
*/
    #endregion

    #region FormSize
    /*
    class MainApp : Form
    {
        static void Main(string[] args)
        {
            MainApp form = new MainApp();
            form.Width = 300;
            form.Height = 200;

            form.MouseDown += new MouseEventHandler(form_MouseDown);

            Application.Run(form);
        }

        static void form_MouseDown(object sender, MouseEventArgs e)
        {
            Form form = (Form)sender;
            int oldWidth = form.Width;
            int oldHeight = form.Height;

            if (e.Button == MouseButtons.Left)
            {
                if(oldWidth < oldHeight)
                {
                    form.Width = oldHeight;
                    form.Height = oldWidth;
                }
            }
            else if(e.Button == MouseButtons.Right)
            {
                if(oldHeight < oldWidth)
                {
                    form.Width = oldHeight;
                    form.Height = oldWidth;
                }
            }
            Console.WriteLine("Window size has changed.");
            Console.WriteLine($"Width: {form.Width}, Height: {form.Height}");
        }
    }
    */
    #endregion

    #region FormBackGround
    /*
class MainApp : Form
{
    Random rand;

    static void Main(string[] args)
    {
        Application.Run(new MainApp());
    }

    public MainApp()
    {
        rand = new Random();
        this.MinimizeBox = true;
        this.MaximizeBox = true;
        this.Text = "Image Background";
        this.MouseWheel += new MouseEventHandler(MainApp_MouseWheel);
        this.MouseDown += new MouseEventHandler(MainApp_MouseDown);
    }

    void MainApp_MouseWheel(object sender, MouseEventArgs e)
    {
        this.Opacity = this.Opacity + (e.Delta > 0 ? 0.1 : -0.1);
        Console.WriteLine($"Opacity: {this.Opacity}");
    }

    void MainApp_MouseDown(object sender, MouseEventArgs e)
    {
        if(e.Button == MouseButtons.Left)
        {
            Color oldColor = this.BackColor;
            this.BackColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
        }
        else if(e.Button == MouseButtons.Right)
        {
            if(this.BackgroundImage != null)
            {
                this.BackgroundImage = null;
                return;
            }

            string file = "img.png";
            if (!System.IO.File.Exists(file))
                MessageBox.Show("No image file");
            else
            {
                this.BackgroundImage = Image.FromFile(file);
                this.Size = this.BackgroundImage.Size;
            }
        }
    }
}
*/
    #endregion

    #region FromAndControl
        /*
    class MainApp : Form
    {
        static void Main(string[] args)
        {
            Button button = new Button();

            button.Text = "Click!";
            button.Left = 50;
            button.Top = 20;

            button.Click += (object sender, EventArgs e) =>
            {
                MessageBox.Show("MessageBox!");
            };

            MainApp form = new MainApp();
            form.Text = "Form & Control";
            form.Height = 150;
            form.Controls.Add(button);

            Application.Run(form);
        }
    }
    */
    #endregion
    
}
