﻿Imports DevExpress.Utils.Serializing
Imports DevExpress.XtraReports
Imports DevExpress.XtraReports.UI
Imports System.ComponentModel
Imports DevExpress.XtraReports.Expressions

Namespace Reporting_Create_Custom_Numeric_Label
	<ToolboxItem(True), DefaultBindableProperty("Number")>
	Public Class XRNumericLabel
		Inherits XRLabel

		<DefaultValue(0), XtraSerializableProperty>
		Public Property Number() As Integer

		' Set the "Browsable" and "EditorBrowsable" attributes to "false" and "Never"
		' to hide the "Text" property from the "Properties" window and editor (IntelliSense).
		<Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
		Public Overrides Property Text() As String
			Get
				Return Number.ToString()
			End Get
			Set(ByVal value As String)
				Dim i As Integer = Nothing
				Number = If(Integer.TryParse(value, i), i, 0)
			End Set
		End Property

		' Implement a static constructor as shown below to add
		' the "Number" property to the property grid's "Expressions" tab.
		Shared Sub New()
			' Specify an array of events in which the property should be available.
			Dim eventNames() As String = { "BeforePrint" }

			' Specify the property position in the property grid's "Expressions" tab.
			' 0 - fist, 1000 - last.
			Dim position As Integer = 0

			' Specify an array of the property's inner properties.
			Dim nestedBindableProperties() As String = Nothing

			' Specify the property's category in the property grid's "Expressions" tab.
			' The empty string corresponds the root category.
			Dim scopeName As String = ""

			' Create and set description for the "Number" property.
			Dim description As New ExpressionBindingDescription(eventNames, position, nestedBindableProperties, scopeName)

			ExpressionBindingDescriptor.SetPropertyDescription(GetType(XRNumericLabel), NameOf(Number), description)
		End Sub
	End Class
End Namespace
