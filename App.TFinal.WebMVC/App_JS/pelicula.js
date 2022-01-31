(function (pelicula) {
    pelicula.success = successReload;
    initPaginacion();

    function successReload(option) {
        appVentas.closeModal(option);
    }

    function initPaginacion() {
        $('#peliculaTable').DataTable({
            "paging": true,
            "lengthChange": true,
            "searching": true,
            "ordering": true,
            "autoWidth": false,
            "responsive": false/*,
            "buttons":["copy","csv","excel","pdf"]*/
        });//.buttons().container().appenTo("#categoriaTable");
    }
})(window.pelicula = window.pelicula || {})