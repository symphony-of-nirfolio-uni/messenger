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
					Name = "label3",
					Size = new System.Drawing.Size(57, 13),
					TabIndex = 1,
					Text = "Something " + i.ToString()
				};

				Label label_2 = new System.Windows.Forms.Label
				{
					Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))),
					AutoSize = true,
					Location = new System.Drawing.Point(227, 5),
					Name = "label4",
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
					Name = "label5",
					Size = new System.Drawing.Size(50, 13),
					TabIndex = 3,
					Text = "Message"
				};

				Panel panel = new Panel
				{
					BackColor = System.Drawing.Color.Gray,
					Location = new System.Drawing.Point(3, 3),
					Name = "panel1",
					Size = new System.Drawing.Size(listOfChatFlowLayoutPanel.ClientSize.Width - 7, 58),
					TabIndex = 0
				};
				panel.Controls.Add(label_1);
				panel.Controls.Add(label_2);
				panel.Controls.Add(label_3);
				panel.Controls.Add(pictureBox_1);


				listOfChatFlowLayoutPanel.Controls.Add(panel);
			}
		}

		private void ListOfChatFlowLayoutPanel_SizeChanged(object sender, EventArgs e)
		{
			foreach (Control control in listOfChatFlowLayoutPanel.Controls)
			{
				control.Width = listOfChatFlowLayoutPanel.ClientRectangle.Width - 7;
			}
			listOfChatFlowLayoutPanel.SuspendLayout();
			listOfChatFlowLayoutPanel.ResumeLayout();
			listOfChatFlowLayoutPanel.PerformLayout();
		}
	}
}
