(function (cartelera) {
    cartelera.success = successReload;
    initPaginacion();


    function successReload(option) {
        appVentas.closeModal(option);

        getCarteleras();
    }

    function getCarteleras() {
        var url = '/Cartelera/List';
        console.log(url);
        $.get(url, function (data) {
            $('#carteleraList').html(data);
            initPaginacion();
        })
    }

    function initPaginacion() {
        $('#carteleraTable').DataTable({
            "paging": true,
            "lengthChange": true,
            "searching": true,
            "ordering": true,
            "autoWidth": false,
            "responsive": false/*,
            "buttons":["copy","csv","excel","pdf"]*/
        });//.buttons().container().appenTo("#categoriaTable");
    }

    function searchByFilter() {
        var peliculaid = document.getElementById("horario");
        var categoriaName = document.getElementById("categoriaName");
        var tipoCategoriaViewBag = document.getElementById("TipoCategoriaViewData").value;
        var tipoCategoriaViewData = document.getElementById("TipoCategoriaViewBag").value;

        console.log(categoriaId.value + '----' + categoriaName.value);
        console.log(tipoCategoriaViewBag);
        console.log(tipoCategoriaViewData);

        if (categoriaId.value == '') categoriaId.value = '-';
        if (categoriaName.value == '') categoriaName.value = '-';

        //var url = 'Categoria/ListByFilters/?categoriaId=' + categoriaId.value + '&&categoriaNombre=' + categoriaName.value;
        var url = '/Categoria/ListByFilters/' + categoriaId.value + '/' + categoriaName.value;
        console.log(url);
        $.get(url, function (data) {
            $('#categoriaList').html(data);
            initPaginacion();
        })
    }
})(window.cartelera = window.cartelera || {})