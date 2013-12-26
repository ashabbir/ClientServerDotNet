namespace ChatClient
{
    partial class ChatForm
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
            this.pnlChat = new System.Windows.Forms.Panel();
            this.ChatWorld = new System.Windows.Forms.RichTextBox();
            this.pnlUsers = new System.Windows.Forms.Panel();
            this.pnlWrite = new System.Windows.Forms.Panel();
            this.Btn_Send = new System.Windows.Forms.Button();
            this.chatInput = new System.Windows.Forms.TextBox();
            this.pnlChat.SuspendLayout();
            this.pnlWrite.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlChat
            // 
            this.pnlChat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlChat.Controls.Add(this.ChatWorld);
            this.pnlChat.Location = new System.Drawing.Point(4, 3);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(466, 387);
            this.pnlChat.TabIndex = 0;
            // 
            // ChatWorld
            // 
            this.ChatWorld.Location = new System.Drawing.Point(4, 8);
            this.ChatWorld.Name = "ChatWorld";
            this.ChatWorld.Size = new System.Drawing.Size(450, 372);
            this.ChatWorld.TabIndex = 0;
            this.ChatWorld.Text = "";
            // 
            // pnlUsers
            // 
            this.pnlUsers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlUsers.Location = new System.Drawing.Point(466, 3);
            this.pnlUsers.Name = "pnlUsers";
            this.pnlUsers.Size = new System.Drawing.Size(167, 387);
            this.pnlUsers.TabIndex = 1;
            // 
            // pnlWrite
            // 
            this.pnlWrite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlWrite.Controls.Add(this.Btn_Send);
            this.pnlWrite.Controls.Add(this.chatInput);
            this.pnlWrite.Location = new System.Drawing.Point(4, 396);
            this.pnlWrite.Name = "pnlWrite";
            this.pnlWrite.Size = new System.Drawing.Size(624, 32);
            this.pnlWrite.TabIndex = 2;
            // 
            // Btn_Send
            // 
            this.Btn_Send.Location = new System.Drawing.Point(460, 4);
            this.Btn_Send.Name = "Btn_Send";
            this.Btn_Send.Size = new System.Drawing.Size(157, 23);
            this.Btn_Send.TabIndex = 1;
            this.Btn_Send.Text = "Send";
            this.Btn_Send.UseVisualStyleBackColor = true;
            this.Btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
            // 
            // chatInput
            // 
            this.chatInput.Location = new System.Drawing.Point(1, 4);
            this.chatInput.Name = "chatInput";
            this.chatInput.Size = new System.Drawing.Size(451, 20);
            this.chatInput.TabIndex = 0;
            this.chatInput.TextChanged += new System.EventHandler(this.chatInput_TextChanged);
            // 
            // ChatForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(635, 440);
            this.Controls.Add(this.pnlWrite);
            this.Controls.Add(this.pnlUsers);
            this.Controls.Add(this.pnlChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChatForm";
            this.Text = "Chat";
            this.pnlChat.ResumeLayout(false);
            this.pnlWrite.ResumeLayout(false);
            this.pnlWrite.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.RichTextBox ChatWorld;
        private System.Windows.Forms.Panel pnlUsers;
        private System.Windows.Forms.Panel pnlWrite;
        private System.Windows.Forms.Button Btn_Send;
        private System.Windows.Forms.TextBox chatInput;
    }
}

