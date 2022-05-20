using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace WinUIMVVMGrid {

    [GenerateViewModel(ImplementISupportUIServices=true)]
    public partial class MainViewModel {
        public MainViewModel() {
            Source = ProductsDataModel.GetProducts();

            IList Countries = Source.Select(x => x.Country).Distinct().ToList();
            Columns = new ObservableCollection<TextColumn>() {
                new TextColumn(nameof(Product.ProductName)),
                new ComboBoxColumn(nameof(Product.Country), Countries),
                new TextColumn(nameof(Product.UnitPrice)),
                new DateColumn(nameof(Product.OrderDate))
            };
            Selection = new ObservableCollection<Product>() {Source.ElementAt(0)};
            Selection.CollectionChanged += (s, e) => ShowSelectedRowsCommand.RaiseCanExecuteChanged();
        }

        [GenerateProperty]
        ObservableCollection<Product> source;

        [GenerateProperty]
        ObservableCollection<TextColumn> columns;

        [GenerateProperty]
        ObservableCollection<Product> selection;
        IMessageBoxService MessageBoxService => GetUIService<IMessageBoxService>();

        [GenerateCommand]
        async void ShowSelectedRows() {
            string Text = "";
            foreach (Product product in Selection) {
                Text += product.ProductName + "\r\n";
            }
            await MessageBoxService.ShowAsync(Text, "Selected Products");
        }
        bool CanShowSelectedRows() => Selection.Any();

        [GenerateCommand]
        void AddingNewRow(AddingNewEventArgs e) =>
            e.NewObject = new Product {ProductName = "", Country = "Austria", UnitPrice = 0, OrderDate = System.DateTime.Today};
    }


    public class TextColumn : BindableBase {
        public TextColumn(string fieldname) {
            FieldName = fieldname;
        }
        public string FieldName { get; }
    }
    public class ComboBoxColumn : TextColumn {
        public ComboBoxColumn(string fieldname, IList items) : base(fieldname) {
            Items = items;
        }
        public IList Items { get; }
    }
    public class DateColumn : TextColumn {
        public DateColumn(string fieldname) : base(fieldname) { }
    }
}
