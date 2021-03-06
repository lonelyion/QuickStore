﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Microsoft.VisualBasic;

namespace QuickStore
{
	/** CAGRA
	 * StoreNum		0
	 * TAB TAB		(Status)
	 * StoreName	1
	 * TAB TAB		(ACV)
	 * Address TAB	2
	 * City TAB		3
	 * State TAB	4
	 * Zip TAB		5
	 * TAB TAB		(Country)
	 * PhoneNo		6
	 * TAB TAB		(Fax)
	 * ASMID TAB	7
	 * ENTER ENTER	(Select Chain)
	 * Chain		8
	 */

	/** TIMEX
	 * StoreNum	TAB	3
	 * (TDNum is SKIPPED)
	 * Status TAB	11
	 * StorName TAB	2
	 * Ranking TAB	5
	 * Freqncy TAB	10
	 * Address TAB	6
	 * City	TAB		7
	 * State TAB	8
	 * Zip TAB		9
	 * USA TAB		
	 * ENTER ENTER	(Select Chain)
	 * Chain 		1 (Account)
	 * Code			4
	 */

	/** Farmer John
	 * StoreNum	TAB	1
	 * TAB TAB		(Status)
	 * StorName TAB	0
	 * TAB TAB		(ACV)
	 * TAB TAB		(Freqncy)
	 * Address TAB	2
	 * City	TAB		3
	 * State TAB	4
	 * Zip TAB		5
	 * USA TAB		
	 * PhonoNo TAB	6
	 * Fax TAB		7
	 * ENTER ENTER	(Select Chain)
	 * Chain 		8 (Account)
	 */

	/** Jennie-O Turkey Store
	 * StoreNum	TAB	1
	 * TDNum	
	 * TAB TAB		(Status)
	 * StorName TAB	0
	 * TAB TAB		(ACV)
	 * TAB TAB		(Freqncy)
	 * Address TAB	2
	 * City	TAB		3
	 * State TAB	4
	 * Zip TAB		5
	 * USA TAB		
	 * PhonoNo TAB	6
	 * Fax TAB		7
	 * ENTER ENTER	(Select Chain)
	 * Chain 		8 (Account)
	 */

	/** PepsiCo Warehouse Sales
	 * Store Num		(Inaccessible)
	 * TD Linx			9
	 * Customer Number	2
	 * TAB TAB			(Status)
	 * Store Name		1
	 * TAB TAB			(ACV)
	 * Address			3
	 * City				4
	 * State			5
	 * Postal Code		6
	 * TAB TAB			(County)
	 * USA TAB   
	 * Phone Number		7
	 * TAB TAB			(Fax)
	 * Chain ID			8
	 * Volume			(Inaccessible)
	 * TAB				(Impact)
	 * TAB	 			(Frequency)
	 * Classification	(Inaccessible)
	 * TAB				(Franchise)
	 * Nielsen Market	(Inaccessible)
	 * Corporate (0/1)	11
	 */

	/** Time Warner
	 * Store Num  Logix ID  
	 * Status
	 * Store Name  
	 * ACV  
	 * Type
	 * Address   
	 * City   
	 * State    
	 * Postal Code  
	 * Country  
	 * Phone Number  
	 * Fax Number  
	 * Airport  
	 * Security Area  
	 * Location Type  
	 * Chain  
	 */

	/** Sony USA
	 * Store Num
	 * Status
	 * Store Name
	 * ACV
	 * Address   
	 * City   
	 * State/Province
	 * Postal Code
	 * Country
	 * Phone Number
	 * Fax Number
	 * Chain
	 */

	public partial class Main : Form
	{
		const int CAGRA = 0;
		const int FJ = 1;
		const int JOTS = 2;
		const int PWS = 3;
		const int SCEA = 4;
		const int TMX = 5;

		StreamReader SR;
		string file;
		List<string[]> stores;
		int index;
		string[] data;
		string query;

		bool running;

		public Main()
		{
			InitializeComponent();			
			reset();			
		}

		void reset()
		{
			index = 0;
			stores = new List<string[]>();

			running = false;
			btnOpen.Enabled = false;
			btnRun.Enabled = false;
			btnAnalyze.Enabled = false;
			cbCustomer.Enabled = true;
			btnNext.Enabled = false;

			tbFileName.Clear();
			tbConsole.Clear();

			updateStatusBar();
		}

		void updateStatusBar()
		{
			int progress = (running ? index + 1 : 0);
			tbNumStores.Text = String.Format(" {0,4:0000} / {1,-4:0000}", progress, stores.Count);
			pbProgress.Value = progress;
		}

		private void makeStore()
		{
			btnRun.Enabled = btnNext.Enabled = false;
			System.Threading.Thread.Sleep(750);

			data = stores[index];
			string send, format, search;

			switch (cbCustomer.SelectedIndex)
			{
				case CAGRA: // ConAgra Foods
					send = data[0] + "{TAB}{TAB}" + data[1] + "{TAB}{TAB}" + data[2] + "{TAB}" + data[3] + "{TAB}" +
						data[4] + "{TAB}" + data[5] + "{TAB}USA{TAB}" + data[6] + "{TAB}{TAB}" + data[7] + "{TAB}{ENTER}";
					format = string.Format("{0,3}: {1}", index + 1, data[1]);
					query += (index > 0 ? "', '" : "'") + data[0];
					search = data[8];
					break;
				case FJ: // Farmer John
				case SCEA: // Sony USA
					send = data[1] + "{TAB}{TAB}" + data[0] + "{TAB}{TAB}" + data[2] + "{TAB}" + data[3] + "{TAB}" +
						data[4] + "{TAB}" + data[5] + "{TAB}USA{TAB}" + data[6] + "{TAB}" + data[7] + "{TAB}{ENTER}";
					format = string.Format("{0,3}: {1}", index + 1, data[0]);
					query += (index > 0 ? "', '" : "'") + data[0];
					search = data[8];
					break;
				case JOTS: // Jennie-O
					string td = Interaction.InputBox("Please enter TD Number", String.Format("{0} {1}", data[0], data[1]));
					send = data[1] + "{TAB}" + td + "{TAB}" + data[0] + "{TAB}{TAB}" + data[2] + "{TAB}" + data[3] + "{TAB}" +
						data[4] + "{TAB}" + data[5] + "{TAB}USA{TAB}" + data[6] + "{TAB}" + data[7] + "{TAB}{ENTER}";
					format = string.Format("{0,3}: {1}", index + 1, data[0]);
					query += (index > 0 ? "', '" : "'") + td;
					search = data[8];
					break;
				case PWS: // PepsiCo Warehouse Sales
					send = data[9] + "{TAB}"		// tdlink					
						+ data[2] + "{TAB}"			// customer number
						+ (data[10] == "0" ? "Closed" : "Open") + " {TAB}"	// status
						+ data[1] + "{TAB}{TAB}"	// store name / ACV
						+ data[3] + "{TAB}"			// address
						+ data[4] + "{TAB}"			// city
						+ data[5] + "{TAB}"			// state
						+ data[6] + "{TAB}"			// postal code
						+ "{TAB}USA{TAB}"			// county / USA
						+ data[7] + "{TAB}{TAB}"	// phone / fax
													// corporate flag
						+ (data[11] == "1" ? "{TAB 4} +{TAB 4}" : "")
						+ "{ENTER}";				// chain 

					format = string.Format("{0,3}: {1}", index + 1, data[1]);
					//query += (index > 0 ? "', '" : "'") + data[9];
					search = "";					// dummy assign
					break;
				case TMX: // Timex
				default:
					send = data[3] + "{TAB}" + data[11] + "{TAB}" + data[2] + "{TAB}" + data[5] + "{TAB}" +
						data[10] + "{TAB}" + data[6] + "{TAB}" + data[7] + "{TAB}" + data[8] + "{TAB}" + data[9] + "{TAB}USA{TAB}" + "{TAB}{TAB}"
					// code entry
					+ (!String.IsNullOrWhiteSpace(data[4]) ? "{TAB}" + data[4] + "+{TAB}" : "")
					+"{ENTER}";
					format = string.Format("{0,3}: {1} {2}", index + 1, data[2], data[3]);
					search = data[1];
					break;
			}

			tbConsole.AppendText(format + Environment.NewLine);

			SendKeys.SendWait(send);
			System.Threading.Thread.Sleep(500);			
			SendKeys.SendWait("{ENTER}");		

			// PWS Chain Lookup
			if (cbCustomer.SelectedIndex == PWS)
			{
				string chain = "SELECT Name from tChain WHERE ID = " + data[8];
				Clipboard.SetText(chain);
				search = Interaction.InputBox("SQL Query\n" + chain + "\n has been added to clipboard.\nPlease enter corresponding Chain Name", String.Format("Chain ID {0} for {1}", data[8], data[1]));
			}

			System.Threading.Thread.Sleep(500);
			SendKeys.SendWait(search + "{ENTER}");

			if (cbCustomer.SelectedIndex == TMX || cbCustomer.SelectedIndex == PWS)
			{
				query += (index > 0 ? "', '" : "'") + Interaction.InputBox("After saving store, please enter TD Number", String.Format("{0} {1}", data[2], data[3]));
			}
			updateStatusBar();

			btnRun.Enabled = btnNext.Enabled = true;
		}

		#region Button Clicks

		private void btnOpen_Click(object sender, EventArgs e)
		{
			DialogResult result = openFileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				stores = new List<string[]>();
				file = openFileDialog.FileName;
				tbFileName.Text = file;

				btnAnalyze.Enabled = true;
				btnRun.Enabled = false;
				pbProgress.Value = 0;
			}
		}

		private void btnAnalyze_Click(object sender, EventArgs e)
		{
			btnAnalyze.Enabled = false;
			btnRun.Enabled = true;
			cbCustomer.Enabled = false;

			tbConsole.Clear();
			stores = new List<string[]>();

			using (SR = new StreamReader(file))
			{
				string line = SR.ReadLine();
				while ((line = SR.ReadLine()) != null)
				{
					data = line.Split(',');
					stores.Add(data);

					switch (cbCustomer.SelectedIndex)
					{
						case CAGRA: // ConAgra Foods
							tbConsole.AppendText(data[1] + Environment.NewLine);
							break;
						case FJ: // Farmer John
						case JOTS: // Jennie-O
							tbConsole.AppendText(data[0] + Environment.NewLine);
							break;
						case PWS:
							tbConsole.AppendText(String.Format("{0}", data[1]) + Environment.NewLine);
							break;
						case TMX: // Timex
						default:
							tbConsole.AppendText(String.Format("{0} {1}", data[2], data[3]) + Environment.NewLine);
							break;
					}
					
				}

				pbProgress.Maximum = stores.Count;
				updateStatusBar();
			}

			
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			if (!running)
			{
				query = "SELECT * FROM tStore WHERE " + (cbCustomer.SelectedIndex == 1 ? "Name in ( " : "TDNum IN ( ");

				btnRun.Text = "Stop";
				btnRun.Enabled = false;
				btnOpen.Enabled = running;
				btnAnalyze.Enabled = running;
				cbCustomer.Enabled = running;
				btnNext.Enabled = !running;
				running = true;
				tbConsole.Clear();
			}
			else
			{
				btnRun.Text = "Run";
				query += "' )";
				Clipboard.SetText(query);
				MessageBox.Show("SQL Query\n" + query + "\nadded to clipboard.", "Store Creation Stopped!");
				reset();
			}
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			if (index < stores.Count)
			{
				makeStore();
				index++;
			}

			if (index >= stores.Count)
			{
				btnNext.Enabled = false;
				btnRun.Text = "Run";
				btnOpen.Enabled = false;
				btnAnalyze.Enabled = false;
				cbCustomer.Enabled = true;
				running = false;
				query += "' )";
				Clipboard.SetText(query);
				MessageBox.Show("SQL Query\n" + query + "\nadded to clipboard.", "Store Creation Complete!");
				reset();
			}
		}

		private void cbCustomer_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnOpen.Enabled = true;
		}

		#endregion	

	}
}
