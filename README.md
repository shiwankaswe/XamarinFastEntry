# XamarinFastEntry
Extended features for Xamarin Entry control. 

1. Masked Text Box  
2. Max Length Controller  
3. Numeric Entry  
4. Amount Entry
5. Numeric With Space

This is a free Source that any one can use with their xamarin projects

I have created this project to full fill the one my client requirement, i have seached on the internet to find some library or sample code to full fill my requiremnt, but unluckyly i did not found any good solution. then i decided to make it by my own.
And i need to share what i did with other people to make their task easier

This Created using Exteneding a Behavior<Entry>
  
  How to Use it in the YOur Application
  
  
  
  Import your behaviour Entry into Xaml
  
  xmlns:behaviors="clr-namespace:XamarinFastEntrySample.FastEntry"
  
  
  
  Define the Max Length for the Entry
  
 > <Entry x:Name="maxLengthEntry" Text="{Binding maxLengthEntry, Mode=TwoWay}" HeightRequest="40" Placeholder="" >
 >     <Entry.Behaviors>
 >         <behaviors:XamarinFastEntryBehaviour MaxLength="5" />
 >     </Entry.Behaviors>
 > </Entry>
  
  
  
  Numeric Only Entry
  
  <Entry x:Name="numberOnlyEntry" HeightRequest="40" Text="{Binding numberOnlyEntry, Mode=TwoWay}" Placeholder="" >
      <Entry.Behaviors>
          <behaviors:XamarinFastEntryBehaviour IsNumeric="true" />
      </Entry.Behaviors>
  </Entry>
  
  
  
  Use with Amunt Entry Box
  
  <Entry x:Name="amountOnlyEntry" HeightRequest="40" Text="{Binding amountOnlyEntry, Mode=TwoWay}" Placeholder="" >
      <Entry.Behaviors>
          <behaviors:XamarinFastEntryBehaviour IsAmount="true" />
      </Entry.Behaviors>
  </Entry>
  
  
  
  Max Length With Number only Entry
  
  <Entry x:Name="numberOnlyMaxLengthEntry" HeightRequest="40" Text="{Binding numberOnlyMaxLengthEntry, Mode=TwoWay}" Placeholder="" >
      <Entry.Behaviors>
          <behaviors:XamarinFastEntryBehaviour IsNumeric="true" MaxLength="3" />
      </Entry.Behaviors>
  </Entry>
  
  
  
  Mask Entry
  
  <Entry x:Name="maskEntry" HeightRequest="40" Text="{Binding maskEntry, Mode=TwoWay}" Placeholder="" >
      <Entry.Behaviors>
          <behaviors:XamarinFastEntryBehaviour Mask="## ## ###" />
      </Entry.Behaviors>
  </Entry>
