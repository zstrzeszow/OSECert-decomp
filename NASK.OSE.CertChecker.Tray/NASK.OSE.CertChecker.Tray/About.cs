using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NASK.OSE.CertChecker.Tray;

public class About : Form
{
	private IContainer components;

	private WebBrowser browser;

	public About()
	{
		InitializeComponent();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NASK.OSE.CertChecker.Tray.About));
		this.browser = new System.Windows.Forms.WebBrowser();
		base.SuspendLayout();
		this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
		this.browser.Location = new System.Drawing.Point(0, 0);
		this.browser.MinimumSize = new System.Drawing.Size(20, 20);
		this.browser.Name = "browser";
		this.browser.Size = new System.Drawing.Size(800, 450);
		this.browser.TabIndex = 0;
		this.browser.Url = new System.Uri("https://google.com", System.UriKind.Absolute);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(800, 450);
		base.Controls.Add(this.browser);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "About";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "O OSE";
		base.ResumeLayout(false);
	}
}
