   M S B A M L   `   `   `  ���� G  CMatchingDash, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MatchingDash.SharedMatchingDash.Shared  T PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls )    #MatchingDash.Views.TeacherStep2View   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8
Controller!clr-namespace:MatchingDash.Shared     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  f bGalaSoft.MvvmLight.Platform, Version=5.2.0.37226, Culture=neutral, PublicKeyToken=5f873c45e98af8a1+mvvm http://www.galasoft.ch/mvvmlight  `	 \Xceed.Wpf.Toolkit, Version=2.8.15465.16500, Culture=neutral, PublicKeyToken=ba83ff368b7563c64xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 :d2http://schemas.microsoft.com/expression/blend/2008 	 %   MatchingDash.Shared.DockManager    Closed$  DockManager_Closed�� � Title$< 6Secondary Teacher Education II: MENTOR SCHEDULING FORM�� � DataContext �� *	MenuStep2+   Locator �� Source# [  (  "MahApps.Metro.Controls.MetroWindow   Flyouts +  %MahApps.Metro.Controls.FlyoutsControl  -     Name$ flyoutsControl��.@�#  MahApps.Metro.Controls.Flyout  -     Name$ settingsFlyout��   AreAnimationsEnabled .  $��	100 0 0 0q�   Header$ RECORD VIEW��	   Position$	 Right=�$
��Bold"����� 
 �� RelativeSource
 �� *FindAncestor+ �� AncestorType$ Controls:MetroWindowL� �� Path$ ActualWidth�   FocusedElement ��  �� ElementName$ 
PeopleName��.��� $��10q� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� .+��� $��0��$%��Something above the ScrollPanel���� $��0��$@��:This Flyout animates its opacity when opening and closing.���� $��1��$
��Auto=�.����  �� Orientation$ Vertical=�.+��� $��Search on Name��$
��Left=�$	��Top=�$��25��$��	217,9,0,0q�$	��110��$
��Bold"��� -   $��
PeopleName��$
��Left=�$	��Top=�$��23��$��
310,11,0,0q� �� TextWrapping$ NoWrap=�$	��239��*  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ 	Type here��.��&   System.Windows.Controls.DataGrid  -     Name$ Record��$
��Left=�$	��Top=�$	��500��$	��400��   AutoGenerateColumns .   �� ClearTypeHint$ Enabled=�&   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�   HeadersVisibility$	 All=�$��0,5,0,0q����� *
Teachers+ �� Mode$ TwoWay=�����   MetroDataGrid �� BasedOn# [  �� 
TargetType"  .���  �� Property  �@ AlternatingRowBackground  GrayBrush10 �� Value# �     RowStyle ��   MetroDataGridRow# [ )  #System.Windows.Controls.DataGridRow"     Columns 0	  *System.Windows.Controls.DataGridTextColumn	  ,
  &System.Windows.Controls.DataGridColumn 
  Header$ 
FIRST NAME��  
  
IsReadOnly  . ! 
  MinWidth$	! 200Q�" 	  
FontWeight$
" Bold"�1  +System.Windows.Controls.DataGridBoundColumn#   Binding# �� *	FirstName+	  $ 	LAST NAME��  . $	! 200Q�$
" Bold"�# �� *
LastName+.���� $��Visible=�$��Visible=�$
��Auto��$
��Auto��.��� $
��Auto=�$
��Auto=�$
��Auto��$
��Auto�� �� $��60 ��� $��60 ��� $��60 ��� $	��150 ��� $	��460 ��� $��60 ��� $	��100 ��� $��60 ��� $��60 ��� $��60 ��� $��60 ��� $��60 �.+��� $��
First Name��$
��Left=�$	��Top=�$��25��$��0��$��10,7,0,0q�$	��100���� $��0��$
��Left=�$	��Top=�$��23��$��	125,7,0,0q�$ NoWrap=�$	��160��$ 	Type here������ *	FirstName+$ TwoWay=��� $��0��$
��Left=�$��23��$��	391,7,0,0q�$
 Wrap=�$ 	Type here��$	��Top=�$	��156������ *
LastName+$ TwoWay=��� $��0��$��	Last Name��$
��Left=�$��	302,6,0,0q�$	��Top=�$��26��$��84���� $��0��$��Email��$
��Left=�$��	567,7,0,0q�$	��Top=�$��24��$��84���� $��0��$
��Left=�$��23��$��	670,7,0,0q�$
 Wrap=�$ 	Type here��$	��Top=�$	��269������ *Email+$ TwoWay=��� $��0��$��Grade(s) Subject(s)��$
��Left=�$��	961,8,0,0q�$	��Top=�$	��115���� $��0��$
��Left=�$��23��$��
1131,6,0,0q�$
 Wrap=�$ 	Type here��$	��Top=�$	��184��$ J� RenderTransformOrigin$$ 0.658,0.683&����� *Course+$ TwoWay=��� $��School��$
��Left=�$��	10,10,0,0q�$��1��$	��Top=�$��94���� $
��Left=�$��23��$��
125,11,0,0q�$��1��$
 Wrap=�$ 	Type here��$	��Top=�$	��249������ *School+$ TwoWay=��� $��School Phone��$
��Left=�$��
410,11,0,0q�$��1��$	��Top=�$��88���� $
��Left=�$��23��$��
538,12,0,0q�$��1��$
 Wrap=�$ 	Type here��$	��Top=�$	��177������ *SchoolPhone+$ TwoWay=��� $��Cell/Home Phone��$
��Left=�$��	748,9,0,0q�$��1��$	��Top=�$	��116���� $
��Left=�$��23��$��
892,11,0,0q�$��1��$
 Wrap=�$ 	Type here��$	��Top=�$	��204������ *Phone+�� $��2��$��Room number��$
��Left=�$��	19,10,0,0q�$	��Top=�$	��115���� $
��Left=�$��23��$��
165,10,0,0q�$��2��$
 Wrap=�$ 	Type here��$	��Top=�$	��177������ *Room+$ TwoWay=��� $��Preferred Contact��$
��Left=�$��
410,11,0,0q�$��2��$	��Top=�$	��156���� $��2��$
��Left=�$	��Top=�$��
591,10,0,0q�%   ClearTextButton% . $ select��$��26��$	��144��& �� Text& �� *PreferredContact+$ TwoWay=�.@��� .��Email�� .��Phone�� $=��7Willing to work with more than a pair of these students��$
��Left=�$��	748,9,0,0q�$��2��$	��Top=�$	��311���� $��2��$
��Left=�$	��Top=�$��1078,11,0,0q�% . $ select��$��26��$	��144��& �� *Pair+$ TwoWay=�.@��� .��Yes�� .��No� -   $��3��.+��� $��3��$��Define Schedule��$
��Left=�$��	19,10,0,0q�$	��Top=�$
��1208���� $��3��$	��Day��$
��Left=�$��	19,41,0,0q�$	��Top=�$��61���� -   $	��day��$��3��$
��Left=�$	��Top=�$��	92,41,0,0q�% . $ select��$��26��$	��144��& �� *Day+$ TwoWay=�.@��� .��Monday�� .��	Tuesday�� .��	Wednesday�� .��
Thursday�� .��Friday�� $��Subject��$
��Left=�$��
254,41,0,0q�$��3��$	��Top=�$��88���� -   $��subject��$��3��$
��Left=�$	��Top=�$��
354,41,0,0q�% . $ select��$��26��$	��144��& �� *	Subject+$ TwoWay=�.@��� .��	Algebra 1�� .��	Biology�� .��	Chemestry�� .��Math�� .��PRE-AP Math�� .��	Science�� .��PRE-AP Science�� .��TEKS�� .��Other�� $��Grade��$
��Left=�$��
524,41,0,0q�$��3��$	��Top=�$��88��*  $MahApps.Metro.Controls.NumericUpDown  -   $��grade��$��3��$��637,41,657,84q�'   Speedup' .  (   Minimum$( 3Q�)   Maximum$) 12Q�*   Value* �� *Grade+$ TwoWay=��� $��3��$��
start time��$
��Left=�$��	19,87,0,0q�$	��Top=�$��85��" 	 Xceed.Wpf.Toolkit.TimePicker  -	   $��start��$��3��$��125,87,1107,38q�� 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]+   Value+ �� *	StartTime+$ TwoWay=��� $��End Time��$
��Left=�$��
354,87,0,0q�$��3��$	��Top=�$��88��  -
   $	��end��$��3��$��491,87,741,38q�+ �� *	EndTime+$ TwoWay=��� -   $	��add��$
��Left=�$��
733,81,0,0q�$��3��$	��Top=�$��50��$��32��$	��Add��{��� *IsEnabledAddSchedule+$ OneWay=�.  (System.Windows.Interactivity.Interaction,   Triggers, /  )System.Windows.Interactivity.EventTrigger  -   	EventName$- Click��.  (System.Windows.Interactivity.TriggerBase.   Actions.. /  )GalaSoft.MvvmLight.Command.EventToCommand  /   Command/ �� $ ExecuteAddSchedule�$ OneWay=�  -   $��
stepResult��$��4��$
��Left=�$	��Top=�$	��650��$	��400�� .  0   
IsReadOnly0 . $ Enabled=�$ Display=�$	 All=�$��309,10,333,34q����� *TeachSchedule+$ TwoWay=����� # [ "  .���   �@ AlternatingRowBackground# �   �� # [ "   	  $
 DAYS��$	! 140Q�# �� *Days+$ OneWay=�	  $ 	Sart Time��  . $	! 120Q�$
" Bold"�# �� *	StartTime+	  $ End Time��  . $	! 120Q�$
" Bold"�# �� *	EndTime+	  $ SUBJECT��$	! 140Q�# �� *	Subject+$ OneWay=�	  $ GRADE��$	! 100Q�# �� *Grade+$ OneWay=��� $#��Choose  School district area ��$
��Left=�$��
155,14,0,0q�$��5��$	��Top=�$	��166���� $��5��$
��Left=�$	��Top=�$��
344,14,0,0q�% . $ select��$��26��$	��144��& �� *
District+$ TwoWay=�.@��� .��Denton�� .��
Lewisville�� .��
McKinney�� .��Forth-Worth�� $
��Left=�$��
391,10,0,0q�$��6��$	��Top=�$��60��$��32��{��� *	CanSave+$ OneWay=�,   $- Click��..   / �� $ ExecuteSave�$ OneWay=�.���� $��/Pics/Save.jpg��$��23��$��Stretch=�$��40���� $
��Save��$
��Left=�$��
302,10,0,0q�$��6��$	��Top=�$��32��$��72��$
��Bold"��� $��Reset��$
��Left=�$��
538,10,0,0q�$��6��$	��Top=�$��32��$��74��$
��Bold"��� $
��Left=�$��
637,10,0,0q�$��6��$	��Top=�$��50��$��32��,   $- Click��..   / �� $ ExecuteReset�$ OneWay=�.���� $��/Pics/Reset.png��$��23��$��Stretch=�$��40���� $
��Left=�$��
391,10,0,0q�$��7��$	��Top=�$��60��$��32��{��� *CanViewRecord+$ OneWay=�,   $- Click��..   / �� $ ExecuteRecord�$ OneWay=�.���� $��/Pics/Records.png��$��23��$��41���� $��View RECORDS��$
��Left=�$��
273,13,0,0q�$��7��$	��Top=�$	��100��$��29��$
��Bold"��� $��View RESULTS��$
��Left=�$��
521,10,0,0q�$��7��$	��Top=�$	��101��$��32��$
��Bold"��� $
��Left=�$��
637,13,0,0q�$��7��$	��Top=�$��50��$��29��{��� *CanViewResult+$ OneWay=�,   $- Click��..   / �� $ ExecuteResult�$ OneWay=�.���� $��/Pics/results.jpg��$��23��$��Stretch=�$��40���� $
��Left=�$��	19,10,0,0q�$��4��$	��Top=�$	��217��$	��194��