   M S B A M L   `   `   `  ���� G  CMatchingDash, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MatchingDash.SharedMatchingDash.Shared  T PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls #    MatchingDash.Views.ResultView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     8
Controller!clr-namespace:MatchingDash.Shared     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     f bGalaSoft.MvvmLight.Platform, Version=5.2.0.37226, Culture=neutral, PublicKeyToken=5f873c45e98af8a1+mvvm http://www.galasoft.ch/mvvmlight  %   MatchingDash.Shared.DockManager    Closed$  DockManager_Closed��$	��800��$
��1390�� � Title$ RESULT VIEW�� � DataContext �� *Result+   Locator �� Source# [  (  "MahApps.Metro.Controls.MetroWindow   Flyouts +  %MahApps.Metro.Controls.FlyoutsControl  -     Name$ flyoutsControl��.@�#  MahApps.Metro.Controls.Flyout  -     Name$ settingsFlyout��   AreAnimationsEnabled .  $��	100 0 0 0q�   Header$# RESULT OF NO MATCHING CONTENT��	   Position$	 Right=�$
��Bold"����� 
 �� RelativeSource
 �� *FindAncestor+ �� AncestorType$ Controls:MetroWindowL� �� Path$ ActualWidth�   FocusedElement ��  �� ElementName$ People��.��� $��10q� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� .+��� $��0��$%��Something above the ScrollPanel���� $��0��$@��:This Flyout animates its opacity when opening and closing.���� $��1��$
��Auto=�.����  �� Orientation$ Vertical=�.+��� $�� Search on Name��$
��Left=�$	��Top=�$��25��$��	217,9,0,0q�$	��110��$
��Bold"��� -   $��People��$
��Left=�$	��Top=�$��23��$��
310,11,0,0q� �� TextWrapping$ NoWrap=�$	��239��*  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ 	Type here��.���� -   $��
NoIdentity��$
��Left=�$	��Top=�$��
584,10,0,0q�$��0��   ClearTextButton . $ Select Type ��$��26��$	��236��.@��� .��	Teacher�� .��	Student&   System.Windows.Controls.DataGrid  -     Name$ Record��$
��Left=�$	��Top=�$
��1150��$	��400��   AutoGenerateColumns .   �� ClearTypeHint$ Enabled=�&   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�   HeadersVisibility$	 All=�$��0,5,0,0q�{��� *	CanShow+���� *NoConditionResult+ �� Mode$ OneWay=�����   MetroDataGrid �� BasedOn# [  �� 
TargetType"  .���  �� Property  �@ AlternatingRowBackground  GrayBrush10 �� Value# �     RowStyle ��   MetroDataGridRow# [ )  #System.Windows.Controls.DataGridRow"     Columns 0	  *System.Windows.Controls.DataGridTextColumn	  ,
  &System.Windows.Controls.DataGridColumn  
  Header$  MENTOR TEACHER NAME��! 
  
IsReadOnly! . " 
  MinWidth$	" 200Q�# 	  
FontWeight$
# Bold"�1  +System.Windows.Controls.DataGridBoundColumn$   Binding$ �� *TeacherName+	  $  STUDENT NAME��! . $	" 200Q�$
# Bold"�$ �� *StudentName+	  $  SUBJECT��! . $	" 150Q�$
# Bold"�$ �� *Major+	  $
  HOUR��! . $	" 120Q�$
# Bold"�$ �� *Hour+	  $
  DAYS��$	" 100Q�! . $
# Bold"�$ �� *Days+	  $  SCHOOL��$	" 190Q�! . $
# Bold"�$ �� *School+	  $
  ROOM��$" 90Q�! . $
# Bold"�$ �� *Room+4  .System.Windows.Controls.DataGridTemplateColumn  $  DETAILS��$" 90Q�% 
  Width5  /System.Windows.Controls.DataGridLengthConverter$% SizeToCells ! . &   CellTemplate& �� .R��� $	��eff��-   $��Stretch=�$��Stretch=�$��30��.���� $ ��/Pics/info-square-blue.png��$��20��.���� $��Visible=�.���  �� $��60 ��� $	��430 ��� $��60 �.+��� $�� Name��$
��Left=�$	��Top=�$��25��$��0��$��	217,9,0,0q�$��66���� -   $��
PeopleName��$��0��$
��Left=�$	��Top=�$��23��$��
310,11,0,0q�$ NoWrap=�$	��239��$ 	Type here���� $��SEARCH BASED ON:��$
��Left=�$��	49,10,0,0q�$	��Top=�$	��137��$
��Bold"��� -   $��Identity��$
��Left=�$	��Top=�$��
584,10,0,0q�$��0�� . $ Select Type ��$��26��$	��236��.@��� .��	Teacher�� .��	Student  -	   $��
resultgrid��$��1��$
��Left=�$	��Top=�$
��1340��$	��400�� .  $ Enabled=�$ Display=�$	 All=�$��	10,10,0,0q�{��� *	CanShow+���� *	Results+$ TwoWay=����� # [ "  .���   �@ AlternatingRowBackground# �   �� # [ "   	  $  MENTOR TEACHER NAME��! . $	" 200Q�$
# Bold"�$ �� *TeacherName+	  $  STUDENT NAME��! . $	" 200Q�$
# Bold"�$ �� *StudentName+	  $  SUBJECT��! . $	" 150Q�$
# Bold"�$ �� *Major+	  $
  HOUR��! . $	" 120Q�$
# Bold"�$ �� *Hour+	  $
  DAYS��$	" 100Q�! . $
# Bold"�$ �� *Days+	  $  SCHOOL��$	" 190Q�! . $
# Bold"�$ �� *School+	  $
  ROOM��$" 90Q�! . $
# Bold"�$ �� *Room+	  $  	TRANSPORT��$" 90Q�! . $
# Bold"�$ �� *Transportation+	  $  SECTION��$	" 110Q�! . $
# Bold"�$ �� *	section+  $  DETAILS��$" 90Q�$% SizeToCells ! . & �� .R��� $��info_eff��-
   $��Stretch=�$��Stretch=�$��30��.���� $ ��/Pics/info-square-blue.png��$��20���� $
��Left=�$��
391,10,0,0q�$��2��$	��Top=�$��60��$��32��{��� *	CanSave+$ OneWay=�.  (System.Windows.Interactivity.Interaction'   Triggers' /  )System.Windows.Interactivity.EventTrigger  (   	EventName$( Click��.  (System.Windows.Interactivity.TriggerBase)   Actions.) /  )GalaSoft.MvvmLight.Command.EventToCommand  *   Command* �� $ ExecuteSave�$ OneWay=�.���� $��/Pics/Save.jpg��$��23��$��Stretch=�$��40���� $
��Save��$
��Left=�$��
302,10,0,0q�$��2��$	��Top=�$��32��$��72��$
��Bold"��� $��Reset��$
��Left=�$��
538,10,0,0q�$��2��$	��Top=�$��32��$��74��$
��Bold"��� $
��Left=�$��
637,10,0,0q�$��2��$	��Top=�$��50��$��32��'   $( Click��.)   * �� $ ExecuteReset�$ OneWay=�.���� $��/Pics/Reset.png��$��23��$��Stretch=�$��40���� $
��Left=�$��391,71,0,-42q�$��2��$	��Top=�$��60��$��32��'   $( Click��.)   * �� $ ExecuteView�$ OneWay=�.���� $��/Pics/Records.png��$��23��$��41���� $��results of no matching��$
��Left=�$��215,74,0,-42q�$��2��$	��Top=�$	��159��$��29��$
��Bold"�