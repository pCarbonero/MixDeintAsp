using CrudMaui.ViewModels;

namespace CrudMaui.Views;

public partial class ListadoPersonasView : ContentPage
{
	public ListadoPersonasView()
	{
		InitializeComponent();
	}

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
		clsListadoPersonasVM miVm = this.BindingContext as clsListadoPersonasVM;
		miVm.recargarLista();
    }
}