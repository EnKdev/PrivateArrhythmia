namespace PrivateArrhythmia
{
	partial class FirstTimeSetup
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
			this.label1 = new System.Windows.Forms.Label();
			this.waterMarkTextBoxWorkshopLocation = new PrivateArrhythmia.Backend.WaterMarkTextBox();
			this.buttonConfirm = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(290, 21);
			this.label1.TabIndex = 0;
			this.label1.Text = "Project Arrhythmia Workshop Folder:";
			// 
			// waterMarkTextBoxWorkshopLocation
			// 
			this.waterMarkTextBoxWorkshopLocation.Font = new System.Drawing.Font("Inconsolata", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.waterMarkTextBoxWorkshopLocation.Location = new System.Drawing.Point(12, 33);
			this.waterMarkTextBoxWorkshopLocation.Name = "waterMarkTextBoxWorkshopLocation";
			this.waterMarkTextBoxWorkshopLocation.Size = new System.Drawing.Size(612, 24);
			this.waterMarkTextBoxWorkshopLocation.TabIndex = 2;
			this.waterMarkTextBoxWorkshopLocation.WaterMarkColor = System.Drawing.Color.Gray;
			this.waterMarkTextBoxWorkshopLocation.WaterMarkText = "Example: C:\\Program Files (x86)\\Steam\\steamapps\\workshop\\content\\440310";
			// 
			// buttonConfirm
			// 
			this.buttonConfirm.Location = new System.Drawing.Point(12, 78);
			this.buttonConfirm.Name = "buttonConfirm";
			this.buttonConfirm.Size = new System.Drawing.Size(90, 34);
			this.buttonConfirm.TabIndex = 3;
			this.buttonConfirm.Text = "Submit";
			this.buttonConfirm.UseVisualStyleBackColor = true;
			this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
			// 
			// FirstTimeSetup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(636, 124);
			this.Controls.Add(this.buttonConfirm);
			this.Controls.Add(this.waterMarkTextBoxWorkshopLocation);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Inconsolata", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "FirstTimeSetup";
			this.Text = "Private Arrhythmia - First Time Setup";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private Backend.WaterMarkTextBox waterMarkTextBoxWorkshopLocation;
		private System.Windows.Forms.Button buttonConfirm;
	}
}