public partial class MainView: Fuse.App
{
    public sealed class Fuse_Controls_TextControl_string_Value_Property: Uno.UX.Property<string>
    {
        Fuse.Controls.TextControl _obj;
        public Fuse_Controls_TextControl_string_Value_Property(Fuse.Controls.TextControl obj) { _obj = obj; }
        protected override string OnGet() { return _obj.Value; }
        protected override void OnSet(string v, object origin) { _obj.SetValue(v, origin); }
        protected override void OnAddListener(Uno.UX.ValueChangedHandler<string> listener) { _obj.ValueChanged += listener; }
        protected override void OnRemoveListener(Uno.UX.ValueChangedHandler<string> listener) { _obj.ValueChanged -= listener; }
    }
    public partial class Factory: Uno.UX.IFactory
    {
        internal readonly MainView __parent;
        public Factory(MainView parent)
        {
            __parent = parent;
        }
        static Factory()
        {
        }
        public object New()
        {
            var self = new Fuse.Controls.Circle();
            var temp = new Fuse.Navigation.ActivatingAnimation();
            var temp1 = new Fuse.Animations.Scale();
            var temp2 = new Fuse.Drawing.StaticSolidColor(float4(0.3333333f, 0f, 0.6666667f, 1f));
            self.Width = 20f;
            self.Height = 20f;
            self.Margin = float4(10f, 5f, 10f, 5f);
            temp.Animators.Add(temp1);
            temp1.Factor = 1.3f;
            self.Fill = temp2;
            self.Behaviors.Add(temp);
            return self;
        }
    }
    MainView.Fuse_Controls_TextControl_string_Value_Property pageLabel_Value_inst;
    internal Fuse.Controls.PageControl pageControl;
    internal Fuse.Controls.Text pageLabel;
    static MainView()
    {
    }
    public MainView()
    {
        InitializeUX();
    }
    internal void InitializeUX()
    {
        pageLabel = new Fuse.Controls.Text();
        pageLabel_Value_inst = new MainView.Fuse_Controls_TextControl_string_Value_Property(pageLabel);
        pageControl = new Fuse.Controls.PageControl();
        var temp = new Fuse.Reactive.JavaScript();
        var temp1 = new Fuse.Controls.DockPanel();
        var temp2 = new Fuse.Controls.Page();
        var temp3 = new Fuse.Controls.Text();
        var temp4 = new Fuse.Controls.Rectangle();
        var temp5 = new Fuse.Drawing.StaticSolidColor(float4(0.6666667f, 0.6666667f, 0.6666667f, 1f));
        var temp6 = new Fuse.Controls.Rectangle();
        var temp7 = new Fuse.Drawing.StaticSolidColor(float4(0f, 0f, 0f, 1f));
        var temp8 = new Fuse.Navigation.ActivatingAnimation();
        var temp9 = new Fuse.Triggers.Actions.Set<string>(pageLabel_Value_inst);
        var temp10 = new Fuse.Controls.Page();
        var temp11 = new Fuse.Controls.Text();
        var temp12 = new Fuse.Controls.Panel();
        var temp13 = new Fuse.Controls.Text();
        var temp14 = new Fuse.Controls.Switch();
        var temp15 = new Fuse.Controls.Rectangle();
        var temp16 = new Fuse.Drawing.StaticSolidColor(float4(0.6666667f, 0.6666667f, 0.6666667f, 1f));
        var temp17 = new Fuse.Controls.Rectangle();
        var temp18 = new Fuse.Drawing.StaticSolidColor(float4(0f, 0f, 0f, 1f));
        var temp19 = new Fuse.Navigation.ActivatingAnimation();
        var temp20 = new Fuse.Triggers.Actions.Set<string>(pageLabel_Value_inst);
        var temp21 = new Fuse.Controls.Page();
        var temp22 = new Fuse.Controls.Text();
        var temp23 = new Fuse.Controls.Grid();
        var temp24 = new Fuse.Controls.Text();
        var temp25 = new Fuse.Controls.TextInput();
        var temp26 = new Fuse.Controls.Text();
        var temp27 = new Fuse.Controls.TextInput();
        var temp28 = new Fuse.Controls.Text();
        var temp29 = new Fuse.Controls.TextInput();
        var temp30 = new Fuse.Controls.Text();
        var temp31 = new Fuse.Controls.TextInput();
        var temp32 = new Fuse.Controls.Text();
        var temp33 = new Fuse.Controls.TextInput();
        var temp34 = new Fuse.Controls.Text();
        var temp35 = new Fuse.Controls.TextInput();
        var temp36 = new Fuse.Controls.Text();
        var temp37 = new Fuse.Controls.TextInput();
        var temp38 = new Fuse.Controls.Text();
        var temp39 = new Fuse.Controls.TextInput();
        var temp40 = new Fuse.Controls.Button();
        var temp41 = new ButtonText();
        var temp42 = new Fuse.Controls.Button();
        var temp43 = new ButtonText();
        var temp44 = new Fuse.Controls.Rectangle();
        var temp45 = new Fuse.Drawing.StaticSolidColor(float4(0.6666667f, 0.6666667f, 0.6666667f, 1f));
        var temp46 = new Fuse.Controls.Rectangle();
        var temp47 = new Fuse.Drawing.StaticSolidColor(float4(0f, 0f, 0f, 1f));
        var temp48 = new Fuse.Navigation.ActivatingAnimation();
        var temp49 = new Fuse.Triggers.Actions.Set<string>(pageLabel_Value_inst);
        var temp50 = new Fuse.Controls.PageIndicator(pageControl);
        var temp51 = new Factory(this);
        temp.Code = "module.exports = {\n        };";
        temp.LineNumber = 2;
        temp.FileName = "MainView.ux";
        temp1.Children.Add(pageControl);
        temp1.Children.Add(pageLabel);
        temp1.Children.Add(temp50);
        pageControl.Name = "pageControl";
        pageControl.Children.Add(temp2);
        pageControl.Children.Add(temp10);
        pageControl.Children.Add(temp21);
        temp2.Background = Fuse.Drawing.Brushes.Teal;
        temp2.Children.Add(temp3);
        temp2.Children.Add(temp4);
        temp2.Children.Add(temp6);
        temp2.Behaviors.Add(temp8);
        temp3.Value = "TAP TO FLIP";
        temp3.FontSize = 24f;
        temp3.TextColor = float4(1f, 1f, 1f, 1f);
        temp3.Alignment = Fuse.Elements.Alignment.TopCenter;
        temp3.Margin = float4(5f, 5f, 5f, 5f);
        temp4.Width = 2f;
        Fuse.Elements.Element.HeightProperty.Set(temp4, 100f, global::Fuse.Elements.SizeUnit.Percent);
        temp4.Alignment = Fuse.Elements.Alignment.Left;
        temp4.Opacity = 0.2f;
        temp4.Fill = temp5;
        temp6.Width = 2f;
        Fuse.Elements.Element.HeightProperty.Set(temp6, 100f, global::Fuse.Elements.SizeUnit.Percent);
        temp6.Alignment = Fuse.Elements.Alignment.Right;
        temp6.Opacity = 0.2f;
        temp6.Fill = temp7;
        temp8.Actions.Add(temp9);
        temp9.Value = "FLIP COIN";
        temp10.Background = Fuse.Drawing.Brushes.Teal;
        temp10.Children.Add(temp11);
        temp10.Children.Add(temp12);
        temp10.Children.Add(temp15);
        temp10.Children.Add(temp17);
        temp10.Behaviors.Add(temp19);
        temp11.Value = "TAP TO ROLL";
        temp11.FontSize = 24f;
        temp11.TextColor = float4(1f, 1f, 1f, 1f);
        temp11.Alignment = Fuse.Elements.Alignment.TopCenter;
        temp11.Margin = float4(5f, 5f, 5f, 5f);
        Fuse.Elements.Element.WidthProperty.Set(temp12, 100f, global::Fuse.Elements.SizeUnit.Percent);
        temp12.Alignment = Fuse.Elements.Alignment.BottomCenter;
        temp12.Margin = float4(10f, 10f, 10f, 10f);
        temp12.Children.Add(temp13);
        temp12.Children.Add(temp14);
        temp13.Value = "USE TWO DICE ?";
        temp13.FontSize = 18f;
        temp13.TextColor = float4(1f, 1f, 1f, 1f);
        temp13.Alignment = Fuse.Elements.Alignment.Center;
        temp14.Alignment = Fuse.Elements.Alignment.Right;
        temp15.Width = 2f;
        Fuse.Elements.Element.HeightProperty.Set(temp15, 100f, global::Fuse.Elements.SizeUnit.Percent);
        temp15.Alignment = Fuse.Elements.Alignment.Left;
        temp15.Opacity = 0.2f;
        temp15.Fill = temp16;
        temp17.Width = 2f;
        Fuse.Elements.Element.HeightProperty.Set(temp17, 100f, global::Fuse.Elements.SizeUnit.Percent);
        temp17.Alignment = Fuse.Elements.Alignment.Right;
        temp17.Opacity = 0.2f;
        temp17.Fill = temp18;
        temp19.Actions.Add(temp20);
        temp20.Value = "ROLL DICE";
        temp21.Background = Fuse.Drawing.Brushes.Teal;
        temp21.Children.Add(temp22);
        temp21.Children.Add(temp23);
        temp21.Children.Add(temp44);
        temp21.Children.Add(temp46);
        temp21.Behaviors.Add(temp48);
        temp22.Value = "ENTER OPTIONS";
        temp22.FontSize = 24f;
        temp22.TextColor = float4(1f, 1f, 1f, 1f);
        temp22.Alignment = Fuse.Elements.Alignment.TopCenter;
        temp22.Margin = float4(5f, 5f, 5f, 5f);
        temp23.Columns = "1*,5*";
        temp23.ColumnCount = 2;
        temp23.Margin = float4(10f, 30f, 30f, 30f);
        temp23.Children.Add(temp24);
        temp23.Children.Add(temp25);
        temp23.Children.Add(temp26);
        temp23.Children.Add(temp27);
        temp23.Children.Add(temp28);
        temp23.Children.Add(temp29);
        temp23.Children.Add(temp30);
        temp23.Children.Add(temp31);
        temp23.Children.Add(temp32);
        temp23.Children.Add(temp33);
        temp23.Children.Add(temp34);
        temp23.Children.Add(temp35);
        temp23.Children.Add(temp36);
        temp23.Children.Add(temp37);
        temp23.Children.Add(temp38);
        temp23.Children.Add(temp39);
        temp23.Children.Add(temp40);
        temp23.Children.Add(temp42);
        temp24.Value = "1.";
        temp24.FontSize = 18f;
        temp24.TextColor = float4(1f, 1f, 1f, 1f);
        temp24.Alignment = Fuse.Elements.Alignment.Center;
        temp26.Value = "2.";
        temp26.FontSize = 18f;
        temp26.TextColor = float4(1f, 1f, 1f, 1f);
        temp26.Alignment = Fuse.Elements.Alignment.Center;
        temp28.Value = "3.";
        temp28.FontSize = 18f;
        temp28.TextColor = float4(1f, 1f, 1f, 1f);
        temp28.Alignment = Fuse.Elements.Alignment.Center;
        temp30.Value = "4.";
        temp30.FontSize = 18f;
        temp30.TextColor = float4(1f, 1f, 1f, 1f);
        temp30.Alignment = Fuse.Elements.Alignment.Center;
        temp32.Value = "5.";
        temp32.FontSize = 18f;
        temp32.TextColor = float4(1f, 1f, 1f, 1f);
        temp32.Alignment = Fuse.Elements.Alignment.Center;
        temp34.Value = "6.";
        temp34.FontSize = 18f;
        temp34.TextColor = float4(1f, 1f, 1f, 1f);
        temp34.Alignment = Fuse.Elements.Alignment.Center;
        temp36.Value = "7.";
        temp36.FontSize = 18f;
        temp36.TextColor = float4(1f, 1f, 1f, 1f);
        temp36.Alignment = Fuse.Elements.Alignment.Center;
        temp38.Value = "8.";
        temp38.FontSize = 18f;
        temp38.TextColor = float4(1f, 1f, 1f, 1f);
        temp38.Alignment = Fuse.Elements.Alignment.Center;
        Fuse.Elements.Element.HeightProperty.Set(temp40, 100f, global::Fuse.Elements.SizeUnit.Percent);
        temp40.Children.Add(temp41);
        temp41.Value = "Clear";
        Fuse.Elements.Element.HeightProperty.Set(temp42, 100f, global::Fuse.Elements.SizeUnit.Percent);
        temp42.Children.Add(temp43);
        temp43.Value = "Spin!";
        temp44.Width = 2f;
        Fuse.Elements.Element.HeightProperty.Set(temp44, 100f, global::Fuse.Elements.SizeUnit.Percent);
        temp44.Alignment = Fuse.Elements.Alignment.Left;
        temp44.Opacity = 0.2f;
        temp44.Fill = temp45;
        temp46.Width = 2f;
        Fuse.Elements.Element.HeightProperty.Set(temp46, 100f, global::Fuse.Elements.SizeUnit.Percent);
        temp46.Alignment = Fuse.Elements.Alignment.Right;
        temp46.Opacity = 0.2f;
        temp46.Fill = temp47;
        temp48.Actions.Add(temp49);
        temp49.Value = "SPINNER WHEEL";
        pageLabel.Value = "FLIP COIN";
        pageLabel.TextColor = float4(0.3333333f, 0f, 0.6666667f, 1f);
        pageLabel.Alignment = Fuse.Elements.Alignment.Center;
        pageLabel.Name = "pageLabel";
        global::Fuse.Controls.DockPanel.SetDock(pageLabel, Fuse.Layouts.Dock.Bottom);
        temp50.Alignment = Fuse.Elements.Alignment.Center;
        global::Fuse.Controls.DockPanel.SetDock(temp50, Fuse.Layouts.Dock.Bottom);
        temp50.DotFactory = temp51;
        this.RootNode = temp1;
        this.Theme = Fuse.BasicTheme.BasicTheme.Singleton;
        this.Behaviors.Add(temp);
    }
}
