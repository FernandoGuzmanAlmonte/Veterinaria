/*
 * Created by SharpDevelop.
 * User: FernandoGA
 * Date: 20/05/2020
 * Time: 09:12 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace Veterinaria
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		[STAThread]
    	static void Main()
		{
		    Application.EnableVisualStyles();
		    Application.SetCompatibleTextRenderingDefault(false);
		
		    MainForm main = new MainForm();
		    main.FormClosed += MainForm_Closed;
		    
		    //Mostrando Form Main e InicioDeSesion
		    main.Show();
			main.inicioSesion.Show();
		    main.Close();
		    
		    Application.Run();
		   	
		}	
		
		private static void MainForm_Closed(object sender, FormClosedEventArgs e)
		{
		    ((Form)sender).FormClosed -= MainForm_Closed;
		
		    if (Application.OpenForms.Count == 0)
		    {
		        Application.ExitThread();
		    }
		    else
		    {
		        Application.OpenForms[0].FormClosed += MainForm_Closed;
		    }
		}
				
	}
}
