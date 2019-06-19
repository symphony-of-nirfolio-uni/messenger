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
		public Messenger()
		{
			InitializeComponent();
		}


		private void Messenger_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < 7; ++i)
			{
				PictureBox pictureBox_1 = new System.Windows.Forms.PictureBox
				{
					BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))),
					Location = new System.Drawing.Point(3, 3),
					Name = "pictureBox1",
					Size = new System.Drawing.Size(52, 52),
					TabIndex = 0,
					TabStop = false
				};

				Label label_1 = new System.Windows.Forms.Label
				{
					AutoSize = true,
					Location = new System.Drawing.Point(60, 5),
					Name = "Something",
					Size = new System.Drawing.Size(57, 13),
					TabIndex = 1,
					Text = "Something " + i.ToString()
				};

				Label label_2 = new System.Windows.Forms.Label
				{
					Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))),
					AutoSize = true,
					Location = new System.Drawing.Point(227, 5),
					Name = "Time",
					Size = new System.Drawing.Size(30, 13),
					TabIndex = 2,
					Text = "Time",
					TextAlign = System.Drawing.ContentAlignment.TopRight
				};

				Label label_3 = new System.Windows.Forms.Label
				{
					AutoSize = true,
					ForeColor = System.Drawing.Color.DarkRed,
					Location = new System.Drawing.Point(65, 33),
					Name = "Message",
					Size = new System.Drawing.Size(50, 13),
					TabIndex = 3,
					Text = "Message"
				};

				Label label_4 = new System.Windows.Forms.Label
				{
					AutoSize = true,
					Location = new System.Drawing.Point(0, 0),
					Name = "ID",
					Size = new System.Drawing.Size(50, 13),
					TabIndex = 3,
					Text = "ID" + i.ToString(),
					Visible = false
				};
				
				Panel panel = new Panel
				{
					BackColor = System.Drawing.Color.Gray,
					Location = new System.Drawing.Point(3, 3),
					Name = "panel1",
					Size = new System.Drawing.Size(listOfChat_FlowLayoutPanel.ClientSize.Width - 7, 58),
					TabIndex = 0
				};
				panel.Controls.Add(label_4);
				panel.Controls.Add(label_1);
				panel.Controls.Add(label_2);
				panel.Controls.Add(label_3);
				panel.Controls.Add(pictureBox_1);

				panel.Click += new EventHandler(this.CreateChat);

				this.listOfChat_FlowLayoutPanel.Controls.Add(panel);
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

				for (int i = 0; i < 7; ++i)
				{
					PictureBox pictureBox_1 = new System.Windows.Forms.PictureBox
					{
						BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))),
						Location = new System.Drawing.Point(3, 3),
						Name = "pictureBox1",
						Size = new System.Drawing.Size(52, 52),
						TabIndex = 0,
						TabStop = false
					};

					Label label_1 = new System.Windows.Forms.Label
					{
						AutoSize = true,
						Location = new System.Drawing.Point(60, 5),
						Name = "Something",
						Size = new System.Drawing.Size(57, 13),
						TabIndex = 1,
						Text = "Something " + i.ToString()
					};

					Label label_2 = new System.Windows.Forms.Label
					{
						Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))),
						AutoSize = true,
						Location = new System.Drawing.Point(227, 5),
						Name = "Time",
						Size = new System.Drawing.Size(30, 13),
						TabIndex = 2,
						Text = "Time",
						TextAlign = System.Drawing.ContentAlignment.TopRight
					};

					Label label_3 = new System.Windows.Forms.Label
					{
						AutoSize = true,
						ForeColor = System.Drawing.Color.DarkRed,
						Location = new System.Drawing.Point(65, 33),
						Name = "Message",
						Size = new System.Drawing.Size(50, 13),
						TabIndex = 3,
						Text = "Message"
					};

					Label label_4 = new System.Windows.Forms.Label
					{
						AutoSize = true,
						Location = new System.Drawing.Point(0, 0),
						Name = "ID",
						Size = new System.Drawing.Size(50, 13),
						TabIndex = 3,
						Text = "ID" + i.ToString(),
						Visible = false
					};

					Panel panel = new Panel
					{
						BackColor = System.Drawing.Color.Gray,
						Location = new System.Drawing.Point(3, 3),
						Name = "panel1",
						Size = new System.Drawing.Size(listOfChat_FlowLayoutPanel.ClientSize.Width - 7, 58),
						TabIndex = 0
					};
					panel.Controls.Add(label_1);
					panel.Controls.Add(label_2);
					panel.Controls.Add(label_3);
					panel.Controls.Add(pictureBox_1);


					this.chat_FlowLayoutPanel.Controls.Add(panel);
				}

			}
		}

		private void ListOfChat_FlowLayoutPanel_SizeChanged(object sender, EventArgs e)
		{
			foreach (Control control in listOfChat_FlowLayoutPanel.Controls)
			{
				control.Width = listOfChat_FlowLayoutPanel.ClientRectangle.Width - 7;
			}
			listOfChat_FlowLayoutPanel.SuspendLayout();
			listOfChat_FlowLayoutPanel.ResumeLayout();
			listOfChat_FlowLayoutPanel.PerformLayout();
		}

		

		private void Chat_FlowLayoutPanel_SizeChanged(object sender, EventArgs e)
		{
			foreach (Control control in listOfChat_FlowLayoutPanel.Controls)
			{
				control.Width = listOfChat_FlowLayoutPanel.ClientRectangle.Width - 7;
			}
			listOfChat_FlowLayoutPanel.SuspendLayout();
			listOfChat_FlowLayoutPanel.ResumeLayout();
			listOfChat_FlowLayoutPanel.PerformLayout();
		}


		private void Message_TextBox_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
