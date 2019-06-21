using System;
using System.Windows.Forms;

namespace Messenger
{
	partial class Messenger
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.main_SplitContainer = new System.Windows.Forms.SplitContainer();
			this.control_SplitContainer = new System.Windows.Forms.SplitContainer();
			this.option_PictureBox = new System.Windows.Forms.PictureBox();
			this.listOfChat_FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.chat_SplitContainer = new System.Windows.Forms.SplitContainer();
			this.messages_SplitContainer = new System.Windows.Forms.SplitContainer();
			this.chat_FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.message_TextBox = new System.Windows.Forms.TextBox();
			this.companion_Label = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.main_SplitContainer)).BeginInit();
			this.main_SplitContainer.Panel1.SuspendLayout();
			this.main_SplitContainer.Panel2.SuspendLayout();
			this.main_SplitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.control_SplitContainer)).BeginInit();
			this.control_SplitContainer.Panel1.SuspendLayout();
			this.control_SplitContainer.Panel2.SuspendLayout();
			this.control_SplitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.option_PictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chat_SplitContainer)).BeginInit();
			this.chat_SplitContainer.Panel1.SuspendLayout();
			this.chat_SplitContainer.Panel2.SuspendLayout();
			this.chat_SplitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.messages_SplitContainer)).BeginInit();
			this.messages_SplitContainer.Panel1.SuspendLayout();
			this.messages_SplitContainer.Panel2.SuspendLayout();
			this.messages_SplitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// main_SplitContainer
			// 
			this.main_SplitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.main_SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.main_SplitContainer.Location = new System.Drawing.Point(0, 0);
			this.main_SplitContainer.Name = "main_SplitContainer";
			// 
			// main_SplitContainer.Panel1
			// 
			this.main_SplitContainer.Panel1.AutoScroll = true;
			this.main_SplitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
			this.main_SplitContainer.Panel1.Controls.Add(this.control_SplitContainer);
			this.main_SplitContainer.Panel1MinSize = 180;
			// 
			// main_SplitContainer.Panel2
			// 
			this.main_SplitContainer.Panel2.AutoScroll = true;
			this.main_SplitContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.main_SplitContainer.Panel2.Controls.Add(this.chat_SplitContainer);
			this.main_SplitContainer.Panel2MinSize = 300;
			this.main_SplitContainer.Size = new System.Drawing.Size(800, 500);
			this.main_SplitContainer.SplitterDistance = 266;
			this.main_SplitContainer.TabIndex = 0;
			// 
			// control_SplitContainer
			// 
			this.control_SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.control_SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.control_SplitContainer.IsSplitterFixed = true;
			this.control_SplitContainer.Location = new System.Drawing.Point(0, 0);
			this.control_SplitContainer.Name = "control_SplitContainer";
			this.control_SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// control_SplitContainer.Panel1
			// 
			this.control_SplitContainer.Panel1.Controls.Add(this.option_PictureBox);
			// 
			// control_SplitContainer.Panel2
			// 
			this.control_SplitContainer.Panel2.Controls.Add(this.listOfChat_FlowLayoutPanel);
			this.control_SplitContainer.Size = new System.Drawing.Size(266, 500);
			this.control_SplitContainer.SplitterDistance = 70;
			this.control_SplitContainer.TabIndex = 0;
			// 
			// option_PictureBox
			// 
			this.option_PictureBox.Image = global::Messenger.Properties.Resources.Option;
			this.option_PictureBox.Location = new System.Drawing.Point(12, 12);
			this.option_PictureBox.Name = "option_PictureBox";
			this.option_PictureBox.Size = new System.Drawing.Size(48, 48);
			this.option_PictureBox.TabIndex = 0;
			this.option_PictureBox.TabStop = false;
			this.option_PictureBox.Click += new System.EventHandler(this.Option_PictureBox_Click);
			this.option_PictureBox.MouseLeave += new System.EventHandler(this.Option_PictureBox_MouseLeave);
			this.option_PictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Option_PictureBox_MouseMove);
			// 
			// listOfChat_FlowLayoutPanel
			// 
			this.listOfChat_FlowLayoutPanel.AutoScroll = true;
			this.listOfChat_FlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.listOfChat_FlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listOfChat_FlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.listOfChat_FlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.listOfChat_FlowLayoutPanel.Name = "listOfChat_FlowLayoutPanel";
			this.listOfChat_FlowLayoutPanel.Size = new System.Drawing.Size(266, 426);
			this.listOfChat_FlowLayoutPanel.TabIndex = 0;
			this.listOfChat_FlowLayoutPanel.WrapContents = false;
			this.listOfChat_FlowLayoutPanel.SizeChanged += new System.EventHandler(this.ItemList_FlowLayoutPanel_SizeChanged);
			// 
			// chat_SplitContainer
			// 
			this.chat_SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chat_SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.chat_SplitContainer.IsSplitterFixed = true;
			this.chat_SplitContainer.Location = new System.Drawing.Point(0, 0);
			this.chat_SplitContainer.Name = "chat_SplitContainer";
			this.chat_SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// chat_SplitContainer.Panel1
			// 
			this.chat_SplitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
			this.chat_SplitContainer.Panel1.Controls.Add(this.companion_Label);
			// 
			// chat_SplitContainer.Panel2
			// 
			this.chat_SplitContainer.Panel2.Controls.Add(this.messages_SplitContainer);
			this.chat_SplitContainer.Size = new System.Drawing.Size(530, 500);
			this.chat_SplitContainer.SplitterDistance = 70;
			this.chat_SplitContainer.TabIndex = 0;
			// 
			// messages_SplitContainer
			// 
			this.messages_SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.messages_SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.messages_SplitContainer.IsSplitterFixed = true;
			this.messages_SplitContainer.Location = new System.Drawing.Point(0, 0);
			this.messages_SplitContainer.Name = "messages_SplitContainer";
			this.messages_SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// messages_SplitContainer.Panel1
			// 
			this.messages_SplitContainer.Panel1.Controls.Add(this.chat_FlowLayoutPanel);
			// 
			// messages_SplitContainer.Panel2
			// 
			this.messages_SplitContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
			this.messages_SplitContainer.Panel2.Controls.Add(this.message_TextBox);
			this.messages_SplitContainer.Size = new System.Drawing.Size(530, 426);
			this.messages_SplitContainer.SplitterDistance = 370;
			this.messages_SplitContainer.TabIndex = 0;
			// 
			// chat_FlowLayoutPanel
			// 
			this.chat_FlowLayoutPanel.AutoScroll = true;
			this.chat_FlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.chat_FlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chat_FlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
			this.chat_FlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.chat_FlowLayoutPanel.Name = "chat_FlowLayoutPanel";
			this.chat_FlowLayoutPanel.Size = new System.Drawing.Size(530, 370);
			this.chat_FlowLayoutPanel.TabIndex = 0;
			this.chat_FlowLayoutPanel.WrapContents = false;
			this.chat_FlowLayoutPanel.SizeChanged += new System.EventHandler(this.ItemList_FlowLayoutPanel_SizeChanged);
			// 
			// message_TextBox
			// 
			this.message_TextBox.AcceptsTab = true;
			this.message_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.message_TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
			this.message_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.message_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.message_TextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.message_TextBox.Location = new System.Drawing.Point(48, 15);
			this.message_TextBox.Multiline = true;
			this.message_TextBox.Name = "message_TextBox";
			this.message_TextBox.Size = new System.Drawing.Size(379, 20);
			this.message_TextBox.TabIndex = 0;
			this.message_TextBox.WordWrap = false;
			this.message_TextBox.TextChanged += new System.EventHandler(this.Message_TextBox_TextChanged);
			this.message_TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Message_TextBox_KeyDown);
			// 
			// companion_Label
			// 
			this.companion_Label.AutoSize = true;
			this.companion_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.companion_Label.Location = new System.Drawing.Point(147, 21);
			this.companion_Label.Name = "companion_Label";
			this.companion_Label.Size = new System.Drawing.Size(0, 29);
			this.companion_Label.TabIndex = 0;
			// 
			// Messenger
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.ClientSize = new System.Drawing.Size(800, 500);
			this.Controls.Add(this.main_SplitContainer);
			this.DoubleBuffered = true;
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.MinimumSize = new System.Drawing.Size(500, 500);
			this.Name = "Messenger";
			this.Text = "Messenger";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Messenger_FormClosed);
			this.Load += new System.EventHandler(this.Messenger_Load);
			this.Click += new System.EventHandler(this.Messenger_Click);
			this.KeyDown += new KeyEventHandler(this.Messenger_KeyDown);
			this.main_SplitContainer.Panel1.ResumeLayout(false);
			this.main_SplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.main_SplitContainer)).EndInit();
			this.main_SplitContainer.ResumeLayout(false);
			this.control_SplitContainer.Panel1.ResumeLayout(false);
			this.control_SplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.control_SplitContainer)).EndInit();
			this.control_SplitContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.option_PictureBox)).EndInit();
			this.chat_SplitContainer.Panel1.ResumeLayout(false);
			this.chat_SplitContainer.Panel1.PerformLayout();
			this.chat_SplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chat_SplitContainer)).EndInit();
			this.chat_SplitContainer.ResumeLayout(false);
			this.messages_SplitContainer.Panel1.ResumeLayout(false);
			this.messages_SplitContainer.Panel2.ResumeLayout(false);
			this.messages_SplitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.messages_SplitContainer)).EndInit();
			this.messages_SplitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer main_SplitContainer;
		private System.Windows.Forms.SplitContainer control_SplitContainer;
		private System.Windows.Forms.FlowLayoutPanel listOfChat_FlowLayoutPanel;
		private System.Windows.Forms.SplitContainer chat_SplitContainer;
		private System.Windows.Forms.SplitContainer messages_SplitContainer;
		private System.Windows.Forms.TextBox message_TextBox;
		private System.Windows.Forms.FlowLayoutPanel chat_FlowLayoutPanel;
		private PictureBox option_PictureBox;
		private Label companion_Label;
	}
}

