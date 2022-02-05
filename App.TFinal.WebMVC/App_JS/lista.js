(function (lista) {
    lista.success = successReload;
    lista.searchByFilter = searchByFilter;
    lista.searchByFilter2 = searchByFilter2;
   // initPaginacion();

    function successReload (option) {
        appVentas.closeModal(option);
        getCategorias();
    }

    function initPaginacion() {
        $('#listaTable').DataTable({
            "paging": true,
            "lengthChange": true,
            "searching": true,
            "ordering": true,
            "autoWidth": false,
            "responsive": false/*,
            "buttons":["copy","csv","excel","pdf"]*/
        });//.buttons().container().appenTo("#categoriaTable");
    }


    function getCategorias() {
        var url = '/ListaPelicula/List';
        console.log(url);
        $.get(url, function (data) {
            $('#categoriaList').html(data);
            initPaginacion();
        })
    }


    function searchByFilter() {
        var peliculaId = document.getElementById("idpelicula");
        var peliculaName = document.getElementById("horario");

        console.log(peliculaId.value + '----' + peliculaName.value);

        if (peliculaId.value == '') peliculaId.value = '-';
        if (peliculaName.value == '') peliculaName.value = '-';
        var precio = document.getElementById("precio");
        var cantidad = document.getElementById("cantidad");
        console.log(precio.value + '----' + cantidad.value);
        let codx=[peliculaId, peliculaName];
        //codx.push('Fresa')
        codx.forEach(function (elemento, indice, array) {
            console.log(elemento, indice);
        })
        //var url = 'Categoria/ListByFilters/?categoriaId=' + categoriaId.value + '&&categoriaNombre=' + categoriaName.value;
        var url = 'Pago';
        $.get(url, function (data) {
            $('#peliculaList').html(data);
            //initPaginacion();
        })
    }

    function searchByFilter2() {
        var peliculaId = document.getElementById("idpelicula");
        var peliculaName = document.getElementById("horario");
       
        console.log(peliculaId.value + '----' + peliculaName.value);

        if (peliculaId.value == '') peliculaId.value = '-';
        if (peliculaName.value == '') peliculaName.value = '-';
        var precio = document.getElementById("precio");
        var cantidad = document.getElementById("cantidad");
        console.log(precio.value + '----' + cantidad.value);

        codx.forEach(function (elemento, indice, array) {
            console.log(elemento, indice);
        })
       

        //var url = 'Categoria/ListByFilters/?categoriaId=' + categoriaId.value + '&&categoriaNombre=' + categoriaName.value;
       
    }

})(window.lista = window.lista || {})