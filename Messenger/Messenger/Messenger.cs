using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using Data_encryption;

namespace Messenger
{
	public partial class Messenger : Form
	{
		private bool needClearMessageTextBox;

		private HttpRequests httpRequests;
		private string userName;
		private string chatID = "";
		private Panel selectChat;

		private bool optionIsOpen;
		private Panel option_Panel;

		private bool newChatIsOpen;
		private Panel newChat_Panel;

		private bool getPublickeyIsOpen;
		private Panel getPublickey_panel;

		private TextBox publicKey_TextBox;
		private string privateKey;
		private string publicKey;

		private Thread checkMailThread;
		private bool firstStart;

		public Messenger()
		{
			InitializeComponent();

			this.needClearMessageTextBox = false;
			this.httpRequests = new HttpRequests();
			this.userName = "noname";

			this.optionIsOpen = false;
			this.newChatIsOpen = false;
			this.getPublickeyIsOpen = false;
			this.firstStart = true;

			this.privateKey = "";
			this.publicKey = "";
		}


		private void CreateOption_Panel()
		{
			this.option_Panel = new Panel
			{
				BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31))))),
				Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left))),
				AutoSize = true,
				Location = new Point(0, 0),
				Name = "option_Panel",
				Size = new Size(250, this.Height)
			};

			TextBox userName_TextBox = new TextBox
			{
				Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)))),
				BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31))))),
				BorderStyle = System.Windows.Forms.BorderStyle.None,
				Font = new System.Drawing.Font("Microsoft Sans Serif", 12F),
				ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))),
				Location = new System.Drawing.Point(10, 60),
				Name = "userName_TextBox",
				Size = new System.Drawing.Size(200, 20),
				Text = this.userName,
				TabIndex = 0,
				MaxLength = 40,
				WordWrap = false
			};

			Button newChat_Button = new Button
			{
				Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)))),
				BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31))))),
				Name = "newChat_Button",
				Text = "Create new chat",
				Location = new Point(10, 100),
				Size = new Size(200, 40)
			};
			newChat_Button.Click += new EventHandler(this.NewChat_Button_Click);
			
			Button getPublicKey_Button = new Button
			{
				Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)))),
				BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31))))),
				Name = "getPublicKey_Button",
				Text = "Create new chat",
				Location = new Point(10, 150),
				Size = new Size(200, 40)
			};
			getPublicKey_Button.Click += new EventHandler(this.GetPublicKey_Button_Click);

			userName_TextBox.TextChanged += new EventHandler(this.UserName_TextChanged);
			userName_TextBox.LostFocus += new EventHandler(this.UserName_TextBox_LostFocus);

			this.option_Panel.Controls.Add(userName_TextBox);
			this.option_Panel.Controls.Add(newChat_Button);
			this.option_Panel.Controls.Add(getPublicKey_Button);
		}

		private void CreateNewChat_Panel()
		{
			this.newChat_Panel = new Panel
			{
				BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31))))),
				Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left))),
				AutoSize = true,
				Location = new Point(0, 0),
				Name = "newChat_Panel",
				Size = new Size(250, this.Height)
			};

			TextBox name_TextBox = new TextBox
			{
				Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)))),
				BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31))))),
				BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
				Font = new System.Drawing.Font("Microsoft Sans Serif", 12F),
				ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))),
				Location = new System.Drawing.Point(10, 60),
				Name = "name_TextBox",
				Size = new System.Drawing.Size(200, 20),
				TabIndex = 0,
				MaxLength = 40,
				WordWrap = false
			};

			TextBox id_TextBox = new TextBox
			{
				Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)))),
				BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31))))),
				BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
				Font = new System.Drawing.Font("Microsoft Sans Serif", 12F),
				ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))),
				Location = new System.Drawing.Point(10, 90),
				Name = "id_TextBox",
				Size = new System.Drawing.Size(200, 20),
				TabIndex = 0,
				MaxLength = 40,
				WordWrap = false
			};

			Button create_Button = new Button
			{
				Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)))),
				BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31))))),
				Name = "newChat_Button",
				Text = "Create",
				Location = new Point(10, 130),
				Size = new Size(200, 40)
			};
			create_Button.Click += new EventHandler(this.Create_Button_Click);

			this.newChat_Panel.Controls.Add(id_TextBox);
			this.newChat_Panel.Controls.Add(name_TextBox);
			this.newChat_Panel.Controls.Add(create_Button);
		}

		private void CreateGetPublickey_Panel()
		{
			this.getPublickey_panel = new Panel
			{
				BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31))))),
				Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left))),
				AutoSize = true,
				Location = new Point(0, 0),
				Name = "option_Panel",
				Size = new Size(250, this.Height)
			};

			publicKey_TextBox = new TextBox
			{
				Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)))),
				BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31))))),
				BorderStyle = System.Windows.Forms.BorderStyle.None,
				Font = new System.Drawing.Font("Microsoft Sans Serif", 12F),
				ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))),
				Location = new System.Drawing.Point(10, 60),
				Name = "publicKey_TextBox",
				Text = publicKey,
				ReadOnly = true,
				Multiline = true,
				Size = new System.Drawing.Size(200, 400),
				TabIndex = 0
			};

			this.getPublickey_panel.Controls.Add(publicKey_TextBox);
		}


		private void Create_Button_Click(object sender, EventArgs e)
		{
			this.chatID = ((Button)sender).Parent.Controls[0].Text;

			AddChat(((Button)sender).Parent.Controls[1].Text, "34", ((Button)sender).Parent.Controls[0].Text, ((Button)sender).Parent.Controls[1].Text, GetCurrentTimeForMessage());

			CloseOptions();
		}


		private void UserName_TextBox_LostFocus(object sender, EventArgs e)
		{
			if (((TextBox)sender).Text == "")
			{
				MessageBox.Show("User name cannot be emtpy", "User name changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
				((TextBox)sender).Select();
			}
		}

		private void UserName_TextChanged(object sender, EventArgs e)
		{
			if (((TextBox)sender).Text != "")
			{
				this.userName = ((TextBox)sender).Text;
			}
		}
		

		public static void CheckMail(object messenger)
		{
			HttpRequests httpRequests = new HttpRequests();
			while (true)
			{
				string newMessage = httpRequests.GetMessages("fd", "noname");
				httpRequests.DeleteMessages("fd", "noname");

				Thread.Sleep(1000);

				//if (newMessage != "[]")
				//{
				//	MessageBox.Show(newMessage);
				//}
			}
		}

		public void SetNewMessage(string text, string time)
		{
			MessageBox.Show(text);
		}

		private void Messenger_Load(object sender, EventArgs e)
		{
			CreateOption_Panel();
			CreateNewChat_Panel();
			CreateGetPublickey_Panel();

			//loading settings
			//TODO:
			this.firstStart = true;

			if (this.firstStart)
			{
				this.Controls.Remove(this.main_SplitContainer);

				Button generateKeys_button = new Button
				{
					Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)))),
					BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31))))),
					Name = "generateKeys_button",
					Text = "Generate profile, private and public keys",
					Location = new Point(this.Width / 2 - 100, this.Height / 2 - 50),
					Size = new Size(200, 100)
				};
				generateKeys_button.Click += new EventHandler(this.GenerateKeys_button_Click);

				this.Controls.Add(generateKeys_button);
			}

			this.checkMailThread = new Thread(new ParameterizedThreadStart(CheckMail));
			this.checkMailThread.Start(this);

			for (int i = 0; i < 7; ++i)
			{
				AddChat("Something " + i.ToString(), i.ToString(), DataEncryption.GeneratePublicKey(DataEncryption.GeneratePrivateKey()), i.ToString(), "6:53 PM");
			}
			
			this.message_TextBox.Select();
		}


		private void Messenger_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.checkMailThread.Abort();
		}

		private void GenerateKeys_button_Click(object sender, EventArgs e)
		{
			//TODO:
			this.privateKey = DataEncryption.generatePrivateKey();
			this.publicKey = DataEncryption.generatePublicKey(this.privateKey);
			this.publicKey_TextBox.Text = this.publicKey;

			this.Controls.Clear();
			this.Controls.Add(main_SplitContainer);
		}

		private void AddChat(string name, string id, string publicKey, string chatName, string time)
		{
			PictureBox icon_PictureBox = new System.Windows.Forms.PictureBox
			{
				BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))),
				Location = new System.Drawing.Point(3, 3),
				Name = "pictureBox1",
				Size = new System.Drawing.Size(52, 52),
				TabIndex = 0,
				TabStop = false
			};

			Label name_Label = new System.Windows.Forms.Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(60, 5),
				Name = "Something",
				Size = new System.Drawing.Size(57, 13),
				TabIndex = 1,
				Text = name
			};

			Label time_Label = new System.Windows.Forms.Label
			{
				Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))),
				AutoSize = true,
				Location = new System.Drawing.Point(200, 5),
				Name = "Time",
				Size = new System.Drawing.Size(30, 13),
				TabIndex = 2,
				Text = time,
				TextAlign = System.Drawing.ContentAlignment.TopRight
			};

			Label Message_Label = new System.Windows.Forms.Label
			{
				AutoSize = true,
				ForeColor = System.Drawing.Color.DarkRed,
				Location = new System.Drawing.Point(65, 33),
				Name = "Message",
				Size = new System.Drawing.Size(50, 13),
				TabIndex = 3,
				Text = "Message"
			};

			Label id_Label = new System.Windows.Forms.Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(0, 0),
				Name = "ID",
				Size = new System.Drawing.Size(50, 13),
				TabIndex = 3,
				Text = id,
				Visible = false
			};

			Label publicKey_Label = new System.Windows.Forms.Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(0, 0),
				Name = "publicKey_Label",
				Size = new System.Drawing.Size(50, 13),
				TabIndex = 3,
				Text = publicKey,
				Visible = false
			};

			Label nameChat_Label = new System.Windows.Forms.Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(0, 0),
				Name = "nameChat_Label",
				Size = new System.Drawing.Size(50, 13),
				TabIndex = 3,
				Text = chatName,
				Visible = false
			};

			Panel chat_Panel = new Panel
			{
				BackColor = System.Drawing.Color.Gray,
				Location = new System.Drawing.Point(3, 3),
				Name = "panel1",
				Size = new System.Drawing.Size(listOfChat_FlowLayoutPanel.ClientSize.Width - 7, 58),
				TabIndex = 0
			};
			chat_Panel.Controls.Add(id_Label);			//0
			chat_Panel.Controls.Add(name_Label);		//1
			chat_Panel.Controls.Add(time_Label);		//2
			chat_Panel.Controls.Add(Message_Label);		//3
			chat_Panel.Controls.Add(icon_PictureBox);   //4
			chat_Panel.Controls.Add(publicKey_Label);   //5
			chat_Panel.Controls.Add(nameChat_Label);	//6

			chat_Panel.Click += new EventHandler(this.CreateChat);

			this.listOfChat_FlowLayoutPanel.Controls.Add(chat_Panel);
		}

		private void AddMessage(string text, string time, bool forUser = true, bool isLoad = true)
		{
			Size messageBlock_Size = TextRenderer.MeasureText(text, new System.Drawing.Font("Microsoft Sans Serif", 10F), new Size(100, 20), TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);
			messageBlock_Size.Height += 8;
			TextBox messageBlock_TextBox = new TextBox
			{
				Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left))),
				Location = new Point(10, 10),
				BackColor = forUser ? Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45))))) : Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))),
				Font = new System.Drawing.Font("Microsoft Sans Serif", 10F),
				ForeColor = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))),
				BorderStyle = System.Windows.Forms.BorderStyle.None,
				Name = "messageBlock_TextBox",
				Multiline = true,
				ReadOnly = true,
				Size = messageBlock_Size,
				Text = text
			};

			Size time_Size = TextRenderer.MeasureText(time, new System.Drawing.Font("Microsoft Sans Serif", 12F), new Size(47, 13));
			Label time_Label = new Label
			{
				Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right))),
				AutoSize = true,
				Location = new System.Drawing.Point(messageBlock_Size.Width + 20, messageBlock_Size.Height + 8 - time_Size.Height),
				Name = "time_Panel",
				Size = time_Size,
				TabIndex = 1,
				Text = time
			};

			//Size status_Size = new Size(29, 29);
			Size status_Size = new Size(0, 0);
			PictureBox status_PictureBox = new PictureBox
			{
				Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right))),
				Location = new System.Drawing.Point(messageBlock_Size.Width + time_Size.Width + 30, messageBlock_Size.Height + 10 - status_Size.Height),
				Name = "status_PictureBox",
				Size = status_Size,
				TabIndex = 0,
				TabStop = false
			};

			Size message_Size = new Size(messageBlock_Size.Width + time_Size.Width + status_Size.Width + 40, messageBlock_Size.Height + 20);

			Panel lineMessage_Panel = new Panel
			{
				Location = new System.Drawing.Point(3, 307),
				Name = "lineMessage_Panel",
				Size = new System.Drawing.Size(chat_FlowLayoutPanel.ClientSize.Width - 7, message_Size.Height + 20),
				TabIndex = 0
			};

			Panel message_Panel = new Panel
			{
				Anchor = forUser ? AnchorStyles.Left : AnchorStyles.Right,
				BackColor = forUser ? Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45))))) : Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))),
				Location = new System.Drawing.Point(forUser ? 10 : (lineMessage_Panel.Width - message_Size.Width - 10), 10),
				Name = "message_Panel",
				Size = message_Size,
				TabIndex = 1
			};
			message_Panel.Controls.Add(messageBlock_TextBox);
			message_Panel.Controls.Add(time_Label);
			message_Panel.Controls.Add(status_PictureBox);
			
			lineMessage_Panel.Controls.Add(message_Panel);

			this.SuspendLayout();
			this.chat_FlowLayoutPanel.Controls.Add(lineMessage_Panel);
			this.chat_FlowLayoutPanel.Controls.SetChildIndex(lineMessage_Panel, 0);
			this.chat_FlowLayoutPanel.AutoScrollPosition = new Point(22, 100000);
			UpdateFlowLayoutPanel(this.chat_FlowLayoutPanel);

			if (this.selectChat != null && !isLoad)
			{
				this.listOfChat_FlowLayoutPanel.Controls.SetChildIndex(this.selectChat, 0);
				this.selectChat.Controls[3].Text = text;
			}

			if (!isLoad)
			{
				string newMessage = DataEncryption.EncryptMessage(text, this.selectChat.Controls[5].Text);

				this.httpRequests.SendMessage(this.userName, this.selectChat.Controls[6].Text, newMessage);
			}
			this.ResumeLayout();
		}


		private string GetCurrentTimeForMessage()
		{
			return DateTime.Now.Hour.ToString() + ":" + (DateTime.Now.Minute < 10 ? "0" : DateTime.Now.Minute.ToString());
		}

		private void NewChat_Button_Click(object sender, EventArgs e)
		{
			OpenOption(ref this.newChatIsOpen, this.newChat_Panel);
		}
		
		private void GetPublicKey_Button_Click(object sender, EventArgs e)
		{
			OpenOption(ref this.getPublickeyIsOpen, this.getPublickey_panel);
		}


		private void LoadChat(string id)
		{
			for (int i = 0; i < 7; ++i)
			{
				AddMessage("Something " + i.ToString(), "6:53 PM");
			}

			this.message_TextBox.Select();
		}
		
		private void CreateChat(object sender, EventArgs e)
		{
			if (((Panel)sender).Controls[0].Text != this.chatID)
			{
				this.selectChat = (Panel)sender;
				this.chatID = ((Panel)sender).Controls[0].Text;

				this.chat_FlowLayoutPanel.Controls.Clear();

				LoadChat(chatID);
			}
		}


		private void UpdateFlowLayoutPanel(object sender)
		{
			((FlowLayoutPanel)sender).SuspendLayout();
			foreach (Control control in ((FlowLayoutPanel)sender).Controls)
			{
				control.Width = ((FlowLayoutPanel)sender).ClientRectangle.Width - 8;
			}
			((FlowLayoutPanel)sender).PerformLayout();
			((FlowLayoutPanel)sender).ResumeLayout();
		}

		private void ItemList_FlowLayoutPanel_SizeChanged(object sender, EventArgs e)
		{
			UpdateFlowLayoutPanel(sender);
		}

		private void Message_TextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && e.Modifiers != Keys.Shift && e.Modifiers != Keys.Control && this.message_TextBox.Text != "")
			{
				AddMessage(this.message_TextBox.Text, GetCurrentTimeForMessage(), false, false);
				this.needClearMessageTextBox = true;
				UpdateFlowLayoutPanel(this.chat_FlowLayoutPanel);
			}
			else if (e.KeyCode == Keys.J && this.message_TextBox.Text != "")
			{
				AddMessage(this.message_TextBox.Text, GetCurrentTimeForMessage(), true, false);
				this.needClearMessageTextBox = true;
				UpdateFlowLayoutPanel(this.chat_FlowLayoutPanel);
			}
		}

		private void Message_TextBox_TextChanged(object sender, EventArgs e)
		{
			if (this.needClearMessageTextBox)
			{
				this.needClearMessageTextBox = false;
				this.message_TextBox.Text = "";
			}
		}

		//Option part
		private void Option_PictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			this.option_PictureBox.Image = global::Messenger.Properties.Resources.Option_hover_;
		}

		private void Option_PictureBox_MouseLeave(object sender, EventArgs e)
		{
			this.option_PictureBox.Image = global::Messenger.Properties.Resources.Option;
		}
		
		private void Option_PictureBox_Click(object sender, EventArgs e)
		{
			OpenOption(ref this.optionIsOpen, this.option_Panel);
		}
		
		private void OpenOption(ref bool isOpen, Control control)
		{
			isOpen = true;

			this.Controls.Add(control);
			this.Controls.SetChildIndex(control, 0);

			DisableAllControls(this);
			EnableControls(control);
			EnableAllControls(control);
		}

		private void CloseOptions()
		{
			this.optionIsOpen = true;
			this.newChatIsOpen = true;
			this.getPublickeyIsOpen = true;

			EnableAllControls(this);
			if (this.Controls.Contains(this.option_Panel))
			{
				this.Controls.Remove(this.option_Panel);
			}
			if (this.Controls.Contains(this.newChat_Panel))
			{
				this.Controls.Remove(this.newChat_Panel);
			}
			if (this.Controls.Contains(this.getPublickey_panel))
			{
				this.Controls.Remove(this.getPublickey_panel);
			}
		}

		private void Messenger_Click(object sender, EventArgs e)
		{
			if (this.optionIsOpen || this.newChatIsOpen || this.getPublickeyIsOpen)
			{
				if (!((((MouseEventArgs)e).Location.X <= this.option_Panel.Size.Width && ((MouseEventArgs)e).Location.Y <= this.option_Panel.Height)))
				{
					CloseOptions();
				}
			}
		}

		//Enable and Disable Controls
		private void DisableAllControls(Control control)
		{
			foreach (Control contr in control.Controls)
			{
				DisableAllControls(contr);
			}
			control.Enabled = false;
		}

		private void EnableAllControls(Control control)
		{
			foreach (Control contr in control.Controls)
			{
				EnableAllControls(contr);
			}
			control.Enabled = true;
		}

		private void DisableControls(Control control)
		{
			if (control != null)
			{
				control.Enabled = false;
				DisableControls(control.Parent);
			}
		}

		private void EnableControls(Control control)
		{
			if (control != null)
			{
				control.Enabled = true;
				EnableControls(control.Parent);
			}
		}
		
	}
}
