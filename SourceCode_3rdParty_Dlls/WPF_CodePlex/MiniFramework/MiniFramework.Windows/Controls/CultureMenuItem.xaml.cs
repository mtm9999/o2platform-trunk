﻿// <copyright file="CultureMenuItem.xaml.cs" company="Cédric Belin">
// 	Copyright (c) 2007-2009, Cédric Belin &lt;contact@cedric-belin.fr&gt;
// 	GNU Lesser General Public License (LGPLv3) - http://www.gnu.org/licenses/lgpl-3.0.txt
// </copyright>
// <summary>
// 	Implémentation de la classe <c>MiniFramework.Windows.Controls.CultureMenuItem</c>.
// </summary>
// <author>$Author: cedx $</author>
// <date>$Date: 2009-10-05 11:16:06 +0200 (lun. 05 oct. 2009) $</date>
// <version>$Revision: 2020 $</version>

namespace MiniFramework.Windows.Controls
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Windows;
	using System.Windows.Controls;

	using MiniFramework.Collections;
	using MiniFramework.Resources;

	using Messages=MiniFramework.Windows.Properties.Resources;

	//// ========================================================================================

	/// <summary>
	/// Menu de sélection de culture.
	/// </summary>
	public partial class CultureMenuItem: MenuItem
	{
		/// <summary>
		/// Identifie la propriété de dépendance <see cref="SelectedCulture" />.
		/// </summary>
		public static readonly DependencyProperty SelectedCultureProperty=DependencyProperty.Register
		(
			"SelectedCulture",
			typeof(CultureInfo),
			typeof(CultureMenuItem),
			new FrameworkPropertyMetadata(OnSelectedCulturePropertyChanged, OnCoerceValue)
		);

		//// =====================================================================================

		/// <summary>
		/// Initialise une nouvelle instance de la classe <see cref="CultureMenuItem" />.
		/// </summary>
		public CultureMenuItem()
		{
			this.Cultures=new CultureInfoCollection();
			this.InitializeComponent();
		}

		//// =====================================================================================

		/// <summary>
		/// Se produit lorsque la propriété <see cref="SelectedCulture" /> est modifiée.
		/// </summary>
		public event DependencyPropertyChangedEventHandler SelectedCultureChanged;

		//// =====================================================================================

		/// <summary>
		/// Obtient la liste des cultures affichée par ce menu.
		/// </summary>
		/// <value>Liste des cultures affichée par le menu.</value>
		public CultureInfoCollection Cultures
		{
			get;
			private set;
		}

		/// <summary>
		/// Obtient ou définit la culture actuellement sélectionnée.
		/// </summary>
		/// <remarks>
		/// Il s'agit d'une propriété de dépendance.
		/// </remarks>
		/// <value>Culture actuellement sélectionnée, ou une référence null si aucune culture n'est sélectionnée.</value>
		public CultureInfo SelectedCulture
		{
			get { return (CultureInfo) this.GetValue(SelectedCultureProperty); }
			set { this.SetValue(SelectedCultureProperty, value); }
		}

		//// =====================================================================================

		/// <summary>
		/// Convertit cette instance en <see cref="CultureButton" />.
		/// </summary>
		/// <returns>Bouton de sélection de culture équivalent à cette instance.</returns>
		public CultureButton ToCultureButton()
		{
			var control=new CultureButton();

			foreach(var item in this.Cultures) control.Cultures.Add(item);
			control.SelectedCulture=this.SelectedCulture;
			control.SelectedCultureChanged+=delegate { this.SelectedCulture=control.SelectedCulture; };

			return control;
		}

		//// =====================================================================================

		/// <summary>
		/// Déclenche l'événement <see cref="SelectedCultureChanged" />.
		/// </summary>
		/// <param name="e">Objet contenant les données de l'événement.</param>
		protected virtual void OnSelectedCultureChanged(DependencyPropertyChangedEventArgs e)
		{
			var handler=this.SelectedCultureChanged;
			if(handler!=null) handler(this, e);
		}

		//// =====================================================================================

		/// <summary>
		/// Remplit le menu avec les éléments de la collection de cultures sous-jacente.
		/// </summary>
		/// <param name="sender">Objet source de l'événement.</param>
		/// <param name="e">Objet contenant les données de l'événement.</param>
		private void OnSubmenuOpened(object sender, RoutedEventArgs e)
		{
			this.Items.Clear();

			if(this.Cultures.Count==0) this.Items.Add(new MenuItem { Header=Messages.NoEntries, IsEnabled=false });
			else
			{
				foreach(var item in this.Cultures.OrderBy(x=>x.NativeName))
				{
					var menuItem=new MenuItem
					{
						Header=item.NativeName.Capitalize(),
						IsCheckable=true,
						IsChecked=item.Equals(this.SelectedCulture),
						Tag=item.Name
					};

					var icon=item.GetCountryFlag();
					if(icon!=null) menuItem.Icon=new Image { Source=icon.SmallBitmapImage };

					menuItem.Click+=delegate { this.SelectedCulture=CultureInfo.GetCultureInfo(menuItem.Tag.ToString()); };
					this.Items.Add(menuItem);
				}
			}

			e.Handled=true;
		}

		//// =====================================================================================

		/// <summary>
		/// Contraint la valeur de la propriété <see cref="SelectedCulture" />.
		/// </summary>
		/// <param name="sender">Objet dans lequel la propriété a été modifiée.</param>
		/// <param name="baseValue">Valeur de la propriété, avant toute tentative de contrainte.</param>
		private static object OnCoerceValue(DependencyObject sender, object baseValue)
		{
			var control=sender as CultureMenuItem;
			if(control!=null && control.Cultures.Contains((CultureInfo) baseValue)) return baseValue;
			
			return SelectedCultureProperty.DefaultMetadata.DefaultValue;
		}

		/// <summary>
		/// Déclenche l'événement <see cref="SelectedCultureChanged" /> lorsque la valeur de la propriété <see cref="SelectedCulture" /> change.
		/// </summary>
		/// <param name="sender">Objet dans lequel la propriété a été modifiée.</param>
		/// <param name="e">Objet contenant les données de l'événement.</param>
		private static void OnSelectedCulturePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			var control=sender as CultureMenuItem;
			if(control!=null) control.OnSelectedCultureChanged(e);
		}
	}
}