// Grilla Relacionados: Ejecutar y Agendar.
// Grillas Diarios: Ejecutar para Manuales.
// Resto de las Grillas: Ejecutar, Agendar, Relacionados.
function HideContextMenu(gridName) {

    // Si es grilla de Relacionados no mostrar el menú Relacionados
    if (currentGridSelected.name == "MainContent_grdRelatedJobs")
        pmRowMenu.GetItem(6).SetVisible(false);
    else {
        pmRowMenu.GetItem(6).SetVisible(true);
    }

    switch (gridName) {
        case "DailyJobsAutomatico":
            break;
        case "DailyJobsManual":
            pmRowMenu.GetItem(2).SetVisible(true);
            break;
        case "OtherJobsAutomatico":
            pmRowMenu.GetItem(1).SetVisible(true);
            pmRowMenu.GetItem(3).SetVisible(true);
            break;
        case "OtherJobsManual":
            pmRowMenu.GetItem(0).SetVisible(true);
            pmRowMenu.GetItem(5).SetVisible(true);
            break;
        default:

    }
}

function OnGrdJobsGetRowValues(values) {
    try {
        var gridName = "OtherJobs";

        // Si es la grilla de agendados, solo muestra el menu contextual de los procesos manuales no ejecutados.
        if (currentGridSelected.name == "MainContent_grdDailyJobs") {

            if (values[0] == 'Manual' && ((values[1] == 'Ejecutado') || (values[1] == 'Error'))) {
                HideContextMenu("DailyJobsOnlyRelated");
            }
            else {
                HideContextMenu("DailyJobs" + values[0]);
            }
        }
        else {
            HideContextMenu(gridName + values);
        }
    }
    catch (e) {
    }
}

function grid_ContextMenu(s, e) {
    ClearFocusedRows(s, e);

    pmRowMenu.GetItem(0).SetVisible(false);
    pmRowMenu.GetItem(1).SetVisible(false);
    pmRowMenu.GetItem(2).SetVisible(false);
    pmRowMenu.GetItem(3).SetVisible(false);
    pmRowMenu.GetItem(4).SetVisible(false);
    pmRowMenu.GetItem(5).SetVisible(false);
    pmRowMenu.GetItem(6).SetVisible(false);

    if (e.objectType == "row") {
        globalRowIndex = e.index;
        currentGridSelected = s;
        var row = s.GetRow(globalRowIndex);

        currentGridSelected._selectAllRowsOnPage(false);
        currentGridSelected.SetFocusedRowIndex(-1);
        currentGridSelected.SelectRow(e.index, true);

        if (currentGridSelected.name == "MainContent_grdDailyJobs") {
            // OJO: la posición debe ser fija. Solucion mala desde el lado del server.
            var key = row.cells[5].innerHTML + "," + row.cells[7].innerHTML;
            OnGrdJobsGetRowValues(key.split(','));
        }
        else
            OnGrdJobsGetRowValues(row.cells[3].innerHTML);

        pmRowMenu.ShowAtPos(event.clientX, event.clientY);
    }
}
