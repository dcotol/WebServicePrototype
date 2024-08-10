
namespace WCFWindowsHost
{
  partial class Form1
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
      this.lblMessage = new System.Windows.Forms.Label();
      this.btnStart = new System.Windows.Forms.Button();
      this.btnStop = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblMessage
      // 
      this.lblMessage.AutoSize = true;
      this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMessage.Location = new System.Drawing.Point(55, 156);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new System.Drawing.Size(131, 31);
      this.lblMessage.TabIndex = 0;
      this.lblMessage.Text = "Message";
      // 
      // btnStart
      // 
      this.btnStart.Location = new System.Drawing.Point(47, 34);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(254, 89);
      this.btnStart.TabIndex = 1;
      this.btnStart.Text = "Start";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // btnStop
      // 
      this.btnStop.Location = new System.Drawing.Point(324, 34);
      this.btnStop.Name = "btnStop";
      this.btnStop.Size = new System.Drawing.Size(254, 89);
      this.btnStop.TabIndex = 2;
      this.btnStop.Text = "Stop";
      this.btnStop.UseVisualStyleBackColor = true;
      this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(769, 313);
      this.Controls.Add(this.btnStop);
      this.Controls.Add(this.btnStart);
      this.Controls.Add(this.lblMessage);
      this.Name = "Form1";
      this.Text = "Form1";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblMessage;
    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Button btnStop;
  }
}

