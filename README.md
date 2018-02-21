<h1><a id="XamarinFastEntry_0"></a>XamarinFastEntry</h1>
### NuGet
* Available on NuGet: [somostechies.facebook](https://www.nuget.org/packages/XamarinFastEntry.Behaviors) [![NuGet](https://img.shields.io/nuget/v/XamarinFastEntry.Behaviors.svg?label=NuGet)](https://www.nuget.org/packages/XamarinFastEntry.Behaviors/1.0.0)
<p>Extended features for Xamarin Entry control.</p>
<ol>
<li>Masked Text Box</li>
<li>Max Length Controller</li>
<li>Numeric Entry</li>
<li>Amount Entry</li>
<li>Numeric With Space</li>
</ol>
<p>This is a free Source that any one can use with their xamarin projects</p>
<p>I have created this project to full fill the one my project requirement, I have searched on the internet to find some library or sample code, but unluckily I did not found any good solution. then I decided to make it on my own.<br>
And i need to share what i did with other people to make their work easier</p>
<p>This Created using Exteneding a Behavior&lt;Entry&gt;</p>
<p>How to Use it in the YOur Application</p>
<p>Import your behaviour Entry into Xaml</p>
<blockquote>
<p>xmlns:behaviors=“clr-namespace:XamarinFastEntrySample.FastEntry”</p>
</blockquote>
<p>Define the Max Length for the Entry</p>
<blockquote>
<p>&lt;Entry x:Name=“maxLengthEntry” Text=&quot;{Binding maxLengthEntry, Mode=TwoWay}&quot; HeightRequest=“40” Placeholder=&quot;&quot; &gt;<br>
&lt;Entry.Behaviors&gt;<br>
&lt;behaviors:XamarinFastEntryBehaviour MaxLength=“5” /&gt;<br>
&lt;/Entry.Behaviors&gt;<br>
&lt;/Entry&gt;</p>
</blockquote>
<p>Numeric Only Entry</p>
<blockquote>
<p>&lt;Entry x:Name=“numberOnlyEntry” HeightRequest=“40” Text=&quot;{Binding numberOnlyEntry, Mode=TwoWay}&quot; Placeholder=&quot;&quot; &gt;<br>
&lt;Entry.Behaviors&gt;<br>
&lt;behaviors:XamarinFastEntryBehaviour IsNumeric=“true” /&gt;<br>
&lt;/Entry.Behaviors&gt;<br>
&lt;/Entry&gt;</p>
</blockquote>
<p>Use with Amunt Entry Box</p>
<blockquote>
<p>&lt;Entry x:Name=“amountOnlyEntry” HeightRequest=“40” Text=&quot;{Binding amountOnlyEntry, Mode=TwoWay}&quot; Placeholder=&quot;&quot; &gt;<br>
&lt;Entry.Behaviors&gt;<br>
&lt;behaviors:XamarinFastEntryBehaviour IsAmount=“true” /&gt;<br>
&lt;/Entry.Behaviors&gt;<br>
&lt;/Entry&gt;</p>
</blockquote>
<p>Max Length With Number only Entry</p>
<blockquote>
<p>&lt;Entry x:Name=“numberOnlyMaxLengthEntry” HeightRequest=“40” Text=&quot;{Binding numberOnlyMaxLengthEntry, Mode=TwoWay}&quot; Placeholder=&quot;&quot; &gt;<br>
&lt;Entry.Behaviors&gt;<br>
&lt;behaviors:XamarinFastEntryBehaviour IsNumeric=“true” MaxLength=“3” /&gt;<br>
&lt;/Entry.Behaviors&gt;<br>
&lt;/Entry&gt;</p>
</blockquote>
<p>Mask Entry</p>
<blockquote>
<p>&lt;Entry x:Name=“maskEntry” HeightRequest=“40” Text=&quot;{Binding maskEntry, Mode=TwoWay}&quot; Placeholder=&quot;&quot; &gt;<br>
&lt;Entry.Behaviors&gt;<br>
&lt;behaviors:XamarinFastEntryBehaviour Mask=&quot;## ## ###&quot; /&gt;<br>
&lt;/Entry.Behaviors&gt;<br>
&lt;/Entry&gt;</p>
</blockquote>
