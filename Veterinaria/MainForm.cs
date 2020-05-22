/*
 * Created by SharpDevelop.
 * User: FernandoGA
 * Date: 20/05/2020
 * Time: 09:12 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Veterinaria
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public InicioDeSesion inicioSesion;
		
		public MainForm()
		{
			InitializeComponent();
			
			inicioSesion = new InicioDeSesion();
			//El inicioSesion.Show() de inicio sesion está en Program.cs, pero no es necesario moverle haya solo como info
		}
	}
}
