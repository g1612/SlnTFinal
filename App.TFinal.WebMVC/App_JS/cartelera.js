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
})(window.cartelera = window.cartelera || {})