   M S B A M L   `   `   `  ���� G  CMatchingDash, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MatchingDash.SharedMatchingDash.Shared  T PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls !    MatchingDash.Views.MainMenu   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     8
Controller!clr-namespace:MatchingDash.Shared     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  :d2http://schemas.microsoft.com/expression/blend/2008  f bGalaSoft.MvvmLight.Platform, Version=5.2.0.37226, Culture=neutral, PublicKeyToken=5f873c45e98af8a1+mvvm http://www.galasoft.ch/mvvmlight  %   MatchingDash.Shared.DockManager    Closed$  DockManager_Closed��?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid$   SelectiveScrollingOrientation$
 Both=� � Title$( "EDSE 4000-  Classroom Interactions�� � DataContext �� *
MainMenu+   Locator �� Source# [  (  "MahApps.Metro.Controls.MetroWindow   Flyouts +  %MahApps.Metro.Controls.FlyoutsControl  -     Name$ flyoutsControl��.@�#  MahApps.Metro.Controls.Flyout  -     Name$ settingsFlyout��   AreAnimationsEnabled .  $��	100 0 0 0q�	   Header$	 RECORD VIEW��
   Position$
 Right=�$
��Bold"�����  �� RelativeSource �� *FindAncestor+ �� AncestorType$ Controls:MetroWindowL� �� Path$ ActualWidth�   FocusedElement ��  �� ElementName$ 
PeopleName��.��� $��10q� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� .+��� $��0��$%��Something above the ScrollPanel���� $��0��$@��:This Flyout animates its opacity when opening and closing.���� $��1��$
��Auto=�.����  �� Orientation$ Vertical=�.+��� $��Search on Name��$
��Left=�$	��Top=�$��25��$��	217,9,0,0q�$	��110��$
��Bold"��� -   $��
PeopleName��$
��Left=�$	��Top=�$��23��$��
310,11,0,0q� �� TextWrapping$ NoWrap=�$	��239��*  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ 	Type here��.��.��&   System.Windows.Controls.DataGrid  -     Name$ Record��$
��Left=�$	��Top=�$	��500��$	��400��   AutoGenerateColumns .   �� ClearTypeHint$ Enabled=�&   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�   HeadersVisibility$	 All=�$��0,5,0,0q����� *
Teachers+ �� Mode$ TwoWay=�����   MetroDataGrid �� BasedOn# [  �� 
TargetType"  .���  �� Property  �@ AlternatingRowBackground  GrayBrush10 �� Value# �     RowStyle ��   MetroDataGridRow# [ )	  #System.Windows.Controls.DataGridRow" 	    Columns 0
  *System.Windows.Controls.DataGridTextColumn
  ,  &System.Windows.Controls.DataGridColumn    Header$  
FIRST NAME��!   
IsReadOnly! . "   MinWidth$	" 200Q�# 
  
FontWeight$
# Bold"�1  +System.Windows.Controls.DataGridBoundColumn$   Binding$ �� *	FirstName+
  $  	LAST NAME��! . $	" 200Q�$
# Bold"�$ �� *
LastName+.���� $��Visible=�$��Visible=�$
��Auto��$
��Auto��.��� $
��Auto=�$
��Auto=�$
��Auto��$
��Auto�� �� $��60 ��� $��60 ��� $	��460 ��� $��60 ��� $��60 ��� $	��100 ��� $��60 ��� $��60 ��� $��60 ��� $��60 ��� $��60 �.+��� $��
First Name��$
��Left=�$	��Top=�$��25��$��0��$��10,7,0,0q�$	��100���� $��0��$
��Left=�$	��Top=�$��23��$��	125,7,0,0q�$ NoWrap=�$	��160��$ 	Type here������ *	FirstName+$ TwoWay=�{��� *IsEnabledFirstName+�� $��0��$
��Left=�$��23��$��	391,7,0,0q�$
 Wrap=�$ 	Type here��$	��Top=�$	��156������ *
LastName+$ TwoWay=�{��� *IsEnabledLasttName+�� $��0��$��	Last Name��$
��Left=�$��	302,6,0,0q�$	��Top=�$��26��$��84���� $��0��$��	UNT Email��$
��Left=�$��	567,7,0,0q�$	��Top=�$��24��$��84���� $��0��$
��Left=�$��23��$��	670,7,0,0q�$
 Wrap=�$ 	Type here��$	��Top=�$	��269������ *Email+$ TwoWay=�{��� *IsEnabledEmail+�� $��0��$��Major��$
��Left=�$��	961,8,0,0q�$	��Top=�$��67���� $��0��$
��Left=�$��23��$��
1048,6,0,0q�$
 Wrap=�$ 	Type here��$	��Top=�$	��184������ *Major+$ TwoWay=�{��� *IsEnabledMajor+�� $��Address��$
��Left=�$��	10,10,0,0q�$��1��$	��Top=�$��94���� $
��Left=�$��23��$��
125,11,0,0q�$��1��$
 Wrap=�$ 	Type here��$	��Top=�$	��249������ *	Address+$ TwoWay=�{��� *IsEnabledAddress+�� $��Phone��$
��Left=�$��
410,11,0,0q�$��1��$	��Top=�$��55���� $
��Left=�$��23��$��
486,11,0,0q�$��1��$
 Wrap=�$ 	Type here��$	��Top=�$	��177������ *Phone+$ TwoWay=�{��� *IsEnabledPhone+�� $��Alternative Phone��$
��Left=�$��
702,10,0,0q�$��1��$	��Top=�$	��116���� $
��Left=�$��23��$��
846,11,0,0q�$��1��$
 Wrap=�$ 	Type here��$	��Top=�$	��204������ *AlternativePhone+{��� *IsEnabledAlternativePhone+  $��2��$
��Left=�$	��Top=�$	��750��$	��400�� .  $ Enabled=�$ Display=�$	 All=�$��309,10,333,34q�{��� *IsEnabledSchedule+$ OneWay=����� *
Schedule+$ TwoWay=����� # [ "  .���   �@ AlternatingRowBackground# �   �� # [ " 	  
  $
  HOUR��! . $	" 200Q�$
# Bold"�$ �� *Time+4  .System.Windows.Controls.DataGridCheckBoxColumn    MetroDataGridCheckBox%   ElementStyle#% �  &   EditingElementStyle#& �  $  MONDAY��$	" 100Q�$ �� *Monday+' �� UpdateSourceTrigger$' PropertyChanged=�  #% �  #& �  $  TUESDAY��$	" 100Q�$ �� *	Tuesday+$' PropertyChanged=�  #% �  #& �  $  	WEDNESDAY��$	" 100Q�$ �� *	Wednesday+$' PropertyChanged=�  #% �  #& �  $  THURSDAY��$	" 100Q�$ �� *
Thursday+$' PropertyChanged=�  #% �  #& �  $  FRIDAY��$	" 100Q�$ �� *Friday+$' PropertyChanged=��� $)��#Do You Have Your Own Transportation��$
��Left=�$��	10,10,0,0q�$��3��$	��Top=�$	��235���� $��3��$
��Left=�$	��Top=�$��262,10,1050,25q�(   ClearTextButton( . $ select��$��26��$��80��{��� *IsEnabledTransportation+$ OneWay=�) �� Text) �� *Transportation+$ TwoWay=�.@��� .��Yes�� .��No�� $?��9If Neccessary, would you be willing to drive someone else��$
��Left=�$��
365,10,0,0q�$��3��$	��Top=�$	��324���� $��3��$
��Left=�$	��Top=�$��702,10,620,25q�( . $ select��$��26��$��80��{��� *IsEnabledDrive+$ OneWay=�) �� *Drive+$ TwoWay=�.@��� .��Yes�� .��No�� $7��1If necessary, would you be willing to teach alone��$
��Left=�$��
795,10,0,0q�$��3��$	��Top=�$	��322���� $��3��$
��Left=�$	��Top=�$��1131,10,177,25q�( . $ select��$��26��$��80��{��� *IsEnabledTeaching+$ OneWay=�) �� *
Teaching+$ TwoWay=�.@��� .��Yes�� .��No�� $��STEP 2 / 1300 Partner��$
��Left=�$��	10,10,0,0q�$��4��$	��Top=��� $
��Left=�$��23��$��
139,10,0,0q�$��4��$
 Wrap=�$ 	Type here��$	��Top=�$	��235������ *	Partner+{��� *IsEnabledPartner+$ OneWay=��� $��
and School��$
��Left=�$��
379,10,0,0q�$��4��$	��Top=�$��72���� $
��Left=�$��23��$��
456,10,0,0q�$��4��$
 Wrap=�$ 	Type here��$	��Top=�$	��241������ *School+{��� *IsEnabledSchool+$ OneWay=��� $B��<Do You Have a preferred partner from this class? If yes, who��$
��Left=�$��
702,10,0,0q�$��4��$	��Top=��� $
��Left=�$��23��$��1033,10,0,0q�$��4��$
 Wrap=�$ 	Type here��$	��Top=�$	��349������ *PreferredPartner+$ TwoWay=�{��� *IsEnabledPreferredPartner+$ OneWay=��� $W��QPlease rank your district preference(1-4. 1=most preferred and 4=least preffered)��$
��Left=�$��	10,10,0,0q�$��5��$	��Top=�$	��441���� $��Denton��$
��Left=�$��	19,41,0,0q�$��5��$	��Top=�$��69��*  $MahApps.Metro.Controls.NumericUpDown  $��5��$��94,41,1225,34q�*   Speedup* .  +   Minimum$+ 1Q�,   Maximum$, 4Q�$��80��-   Value- �� *DentonDistrict+$ TwoWay=�{��� *IsEnabledDentonDistrict+$ OneWay=��� $��Forth Worth��$
��Left=�$��
187,41,0,0q�$��5��$	��Top=�$��83��  $��5��$��282,41,1029,34q�* .  $+ 1Q�$, 4Q�- �� *ForthWorthDistrict+$ TwoWay=�{��� *IsEnabledForthWorthDistrict+$ OneWay=��� $��
Lewisville��$
��Left=�$��
379,41,0,0q�$��5��$	��Top=�$��82��  $��5��$��470,41,836,34q�* .  $+ 1Q�$, 4Q�- �� *LewisvilleDistrict+$ TwoWay=�{��� *IsEnabledLewisvilleDistrict+$ OneWay=��� $��McKinney��$
��Left=�$��
567,41,0,0q�$��5��$	��Top=�$��96��  $��5��$��670,41,641,34q�* .  $+ 1Q�$, 4Q�- �� *MckinneyDistrict+$ TwoWay=�{��� *IsEnabledMckinneyDistrict+$ OneWay=��� $!��Math majors rank preference��$
��Left=�$��	10,10,0,0q�$��6��$	��Top=�$	��172���� $
��Alg1��$
��Left=�$��
197,10,0,0q�$��6��$	��Top=�$��48��  $��6��$��262,10,1051,25q�* .  $+ 1Q�$, 5Q�- �� *Alg1+$ TwoWay=�{��� *IsEnabledAlg1+$ OneWay=��� $
��Geom��$
��Left=�$��
352,10,0,0q�$��6��$	��Top=�$��65��  $��6��$��434,10,876,25q�* .  $+ 1Q�$, 5Q�- �� *Geom+$ TwoWay=�{��� *IsEnabledGeom+$ OneWay=��� $
��Alg2��$
��Left=�$��
521,10,0,0q�$��6��$	��Top=�$��55��  $��6��$��591,10,715,25q�* .  $+ 1Q�$, 5Q�- �� *Alg2+$ TwoWay=�{��� *IsEnabledAlg2+$ OneWay=��� $��Math Models��$
��Left=�$��
702,10,0,0q�$��6��$	��Top=�$��98��  $��6��$��817,10,486,25q�* .  $+ 1Q�$, 5Q�- �� *	MathModel+$ TwoWay=�{��� *IsEnabledMathModel+$ OneWay=��� $��Pre Cal��$
��Left=�$��
923,10,0,0q�$��6��$	��Top=�$��66��  $��6��$��998,10,312,25q�* .  $+ 1Q�$, 5Q�- �� *PreCal+$ TwoWay=�{��� *IsEnabledPreCal+$ OneWay=��� $ ��Bio Majors rank preference��$
��Left=�$��	10,10,0,0q�$��7��$	��Top=�$	��172���� $��Biology��$
��Left=�$��
197,10,0,0q�$��7��$	��Top=�$��68��  $��7��$��282,10,1029,25q�* .  $+ 1Q�$, 2Q�- �� *	Biology+$ TwoWay=�{��� *IsEnabledBiology+$ OneWay=��� $��Anatomy/Physiology��$
��Left=�$��
379,10,0,0q�$��7��$	��Top=�$	��144��  $��7��$��534,10,780,25q�* .  $+ 1Q�$, 2Q�- �� *AnatomyPhysiology+$ TwoWay=�{��� *IsEnabledAnatomyPhysiology+$ OneWay=��� $!��Willing to teach chemestry?��$
��Left=�$��	10,10,0,0q�$��8��$	��Top=�$	��172���� $��8��$��Center=�$��188,10,1050,25q�( . $ select��$��26��{��� *IsEnabledWillingChemestry+$ OneWay=�) �� *WillingChemestry+$ TwoWay=�.@��� .��Yes/Prefer it�� .��	If needed�� .��No Way�� $J��DAnything else you need to know for scheduling your field placement ?��$
��Left=�$��
357,10,0,0q�$��8��$	��Top=�$	��394���� $
��Left=�$��23��$��
761,10,0,0q�$��8��$
 Wrap=�$ 	Type here��$	��Top=�$	��569������ *AnythingElse+$ TwoWay=�{��� *IsEnabledAnythingElse+$ OneWay=��� $
��Left=�$��
391,10,0,0q�$��9��$	��Top=�$��60��$��32��{��� *	CanSave+$ OneWay=�.  (System.Windows.Interactivity.Interaction.   Triggers. /  )System.Windows.Interactivity.EventTrigger  /   	EventName$/ Click��.  (System.Windows.Interactivity.TriggerBase0   Actions.0 /  )GalaSoft.MvvmLight.Command.EventToCommand  1   Command1 �� $ ExecuteSave�$ OneWay=�.���� $��/Pics/Save.jpg��$��23��$��Stretch=�$��40���� $
��Save��$
��Left=�$��
302,10,0,0q�$��9��$	��Top=�$��32��$��72��$
��Bold"��� $��Reset��$
��Left=�$��
538,10,0,0q�$��9��$	��Top=�$��32��$��74��$
��Bold"��� $
��Left=�$��
637,10,0,0q�$��9��$	��Top=�$��50��$��32��.   $/ Click��.0   1 �� $ ExecuteReset�$ OneWay=�.���� $��/Pics/Reset.png��$��23��$��Stretch=�$��40���� $
��Left=�$��
391,10,0,0q�$��10��$	��Top=�$��60��$��32��{��� *CanViewRecord+$ OneWay=�.   $/ Click��.0   1 �� $ ExecuteRecord�$ OneWay=�.���� $��/Pics/Records.png��$��23��$��41���� $��View RECORDS��$
��Left=�$��
273,13,0,0q�$��10��$	��Top=�$	��100��$��29��$
��Bold"��� $��View RESULTS��$
��Left=�$��
521,10,0,0q�$��10��$	��Top=�$	��101��$��32��$
��Bold"��� $
��Left=�$��
637,13,0,0q�$��10��$	��Top=�$��50��$��29��{��� *CanViewResult+$ OneWay=�.   $/ Click��.0   1 �� $ ExecuteResult�$ OneWay=�.���� $��/Pics/results.jpg��$��23��$��Stretch=�$��40���� $
��Left=�$��	19,10,0,0q�$��2��$	��Top=�$	��217��$	��194������ 2 �� TextWrapping$
2 Wrap=�$����In the table, draw a box arounf and shade in ALL 3-HOUR OR LONGER blocks of times that you ARE AVAILABLE to teach in the table below: A teaching block will include:                                 At leadt 45 min prior to start of teach for travel to school, check-in and set-up; 30 min after teach for clean-up and travel back to campus��