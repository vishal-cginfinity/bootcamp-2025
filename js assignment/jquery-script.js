$(function () {
  $(window).on('employee:selected', function (ev) {
    const emp = ev.detail;
    const $li = $('<li>').text(emp.name + ' — ' + emp.role).attr('data-id', emp.id);
    $('#recentList').prepend($li);

    const $modal = $('#detailModal');
    const $content = $modal.find('.modal-content');

    $modal.show().css('opacity', 0).animate({opacity: 1}, 200);
    $content.hide().slideDown(220);
  });

  
  $('#closeModal').on('click', function () {
    const $modal = $('#detailModal');
    const $content = $modal.find('.modal-content');
    $content.slideUp(160, function () { $modal.animate({opacity:0}, 180, function(){ $modal.hide().css('opacity',''); }); });
  });

  
  $('#recentList').on('click', 'li', function () {
    const id = Number($(this).attr('data-id'));
    const manager = window.EmployeeManager ? new window.EmployeeManager() : null;
    if (manager) {
      manager.loadData(0).then(() => {
        const emp = manager.getById(id);
        if (emp) window.dispatchEvent(new CustomEvent('employee:selected', { detail: emp }));
      });
    }
  });
});
