using System;

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
			this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
			this.controlSplitContainer = new System.Windows.Forms.SplitContainer();
			this.listOfChatFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.chatSplitContainer = new System.Windows.Forms.SplitContainer();
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
			this.mainSplitContainer.Panel1.SuspendLayout();
			this.mainSplitContainer.Panel2.SuspendLayout();
			this.mainSplitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.controlSplitContainer)).BeginInit();
			this.controlSplitContainer.Panel2.SuspendLayout();
			this.controlSplitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chatSplitContainer)).BeginInit();
			this.chatSplitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainSplitContainer
			// 
			this.mainSplitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
			this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.mainSplitContainer.Name = "mainSplitContainer";
			// 
			// mainSplitContainer.Panel1
			// 
			this.mainSplitContainer.Panel1.AutoScroll = true;
			this.mainSplitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
			this.mainSplitContainer.Panel1.Controls.Add(this.controlSplitContainer);
			this.mainSplitContainer.Panel1MinSize = 180;
			// 
			// mainSplitContainer.Panel2
			// 
			this.mainSplitContainer.Panel2.AutoScroll = true;
			this.mainSplitContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.mainSplitContainer.Panel2.Controls.Add(this.chatSplitContainer);
			this.mainSplitContainer.Panel2MinSize = 300;
			this.mainSplitContainer.Size = new System.Drawing.Size(800, 500);
			this.mainSplitContainer.SplitterDistance = 266;
			this.mainSplitContainer.TabIndex = 0;
			// 
			// controlSplitContainer
			// 
			this.controlSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.controlSplitContainer.IsSplitterFixed = true;
			this.controlSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.controlSplitContainer.Name = "controlSplitContainer";
			this.controlSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// controlSplitContainer.Panel2
			// 
			this.controlSplitContainer.Panel2.Controls.Add(this.listOfChatFlowLayoutPanel);
			this.controlSplitContainer.Size = new System.Drawing.Size(266, 500);
			this.controlSplitContainer.SplitterDistance = 70;
			this.controlSplitContainer.TabIndex = 0;
			// 
			// listOfChatFlowLayoutPanel
			// 
			this.listOfChatFlowLayoutPanel.AutoScroll = true;
			this.listOfChatFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.listOfChatFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listOfChatFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.listOfChatFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.listOfChatFlowLayoutPanel.Name = "listOfChatFlowLayoutPanel";
			this.listOfChatFlowLayoutPanel.Size = new System.Drawing.Size(266, 426);
			this.listOfChatFlowLayoutPanel.TabIndex = 0;
			this.listOfChatFlowLayoutPanel.WrapContents = false;
			this.listOfChatFlowLayoutPanel.SizeChanged += new System.EventHandler(this.ListOfChatFlowLayoutPanel_SizeChanged);
			// 
			// chatSplitContainer
			// 
			this.chatSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chatSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.chatSplitContainer.IsSplitterFixed = true;
			this.chatSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.chatSplitContainer.Name = "chatSplitContainer";
			this.chatSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// chatSplitContainer.Panel1
			// 
			this.chatSplitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
			this.chatSplitContainer.Size = new System.Drawing.Size(530, 500);
			this.chatSplitContainer.SplitterDistance = 70;
			this.chatSplitContainer.TabIndex = 0;
			// 
			// Messenger
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.ClientSize = new System.Drawing.Size(800, 500);
			this.Controls.Add(this.mainSplitContainer);
			this.DoubleBuffered = true;
			this.MinimumSize = new System.Drawing.Size(500, 500);
			this.Name = "Messenger";
			this.Text = "Messenger";
			this.Load += new System.EventHandler(this.Messenger_Load);
			this.mainSplitContainer.Panel1.ResumeLayout(false);
			this.mainSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
			this.mainSplitContainer.ResumeLayout(false);
			this.controlSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.controlSplitContainer)).EndInit();
			this.controlSplitContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chatSplitContainer)).EndInit();
			this.chatSplitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer mainSplitContainer;
		private System.Windows.Forms.SplitContainer controlSplitContainer;
		private System.Windows.Forms.FlowLayoutPanel listOfChatFlowLayoutPanel;
		private System.Windows.Forms.SplitContainer chatSplitContainer;
	}
}

