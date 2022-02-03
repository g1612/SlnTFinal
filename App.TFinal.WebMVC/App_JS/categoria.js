(function (categoria) {
    categoria.success = successReload;
    initPaginacion();

    function successReload (option) {
        appVentas.closeModal(option);
    }

    function initPaginacion() {
        $('#categoriaTable').DataTable({
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
        var peliculaId = document.getElementById("peliculaId");
        var peliculaName = document.getElementById("peliculaName");

        console.log(peliculaId.value + '----' + peliculaName.value);

        if (peliculaId.value == '') peliculaId.value = '-';
        if (peliculaName.value == '') peliculaName.value = '-';


        //var url = 'Categoria/ListByFilters/?categoriaId=' + categoriaId.value + '&&categoriaNombre=' + categoriaName.value;
        var url = 'Pelicula/ListByFilters/' + peliculaId.value + '/' + peliculaName.value;
        $.get(url, function (data) {
            $('#peliculaList').html(data);
            initPaginacion();
        })
    }

})(window.categoria = window.categoria || {})