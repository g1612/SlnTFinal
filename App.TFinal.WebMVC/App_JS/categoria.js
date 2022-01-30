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
})(window.categoria = window.categoria || {})