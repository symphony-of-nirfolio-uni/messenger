using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Messenger
{
	public partial class Messenger : Form
	{
		private bool needClearMessageTextBox;

		public Messenger()
		{
			InitializeComponent();

			this.needClearMessageTextBox = false;
		}


		private void Messenger_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < 7; ++i)
			{
				AddChat("Something " + i.ToString(), i.ToString(), "6:53 PM");
			}
			
			this.message_TextBox.Select();
		}

		private void AddChat(string name, string id, string time)
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
				Location = new System.Drawing.Point(220, 5),
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

			Panel chat_Panel = new Panel
			{
				BackColor = System.Drawing.Color.Gray,
				Location = new System.Drawing.Point(3, 3),
				Name = "panel1",
				Size = new System.Drawing.Size(listOfChat_FlowLayoutPanel.ClientSize.Width - 7, 58),
				TabIndex = 0
			};
			chat_Panel.Controls.Add(id_Label);
			chat_Panel.Controls.Add(name_Label);
			chat_Panel.Controls.Add(time_Label);
			chat_Panel.Controls.Add(Message_Label);
			chat_Panel.Controls.Add(icon_PictureBox);

			chat_Panel.Click += new EventHandler(this.CreateChat);

			this.listOfChat_FlowLayoutPanel.Controls.Add(chat_Panel);
		}

		private void AddMessage(string text, string time, bool forUser = true)
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

			Control[] controls = new Control[this.chat_FlowLayoutPanel.Controls.Count + 1];
			controls[0] = lineMessage_Panel;
			int index = 1;
			foreach (Control control in this.chat_FlowLayoutPanel.Controls)
			{
				controls[index] = control;
				++index;
			}
			this.chat_FlowLayoutPanel.PerformLayout();
			this.chat_FlowLayoutPanel.Controls.Clear();
			this.chat_FlowLayoutPanel.Controls.AddRange(controls);
			this.chat_FlowLayoutPanel.AutoScrollPosition = new Point(22, 100000);
			UpdateFlowLayoutPanel(this.chat_FlowLayoutPanel);
			this.chat_FlowLayoutPanel.ResumeLayout();
		}

		private void LoadChat(string id)
		{
			for (int i = 0; i < 7; ++i)
			{
				AddMessage("Something " + i.ToString(), "6:53 PM");
			}

			this.message_TextBox.Select();
		}

		private string chatID = "";

		private void CreateChat(object sender, EventArgs e)
		{
			if (((Panel)sender).Controls[0].Text != chatID)
			{
				chatID = ((Panel)sender).Controls[0].Text;

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
				AddMessage(this.message_TextBox.Text, DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString(), false);
				this.needClearMessageTextBox = true;
				UpdateFlowLayoutPanel(this.chat_FlowLayoutPanel);
			}
			else if (e.KeyCode == Keys.J && this.message_TextBox.Text != "")
			{
				AddMessage(this.message_TextBox.Text, DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString(), true);
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
	}
}
