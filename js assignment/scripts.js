(function () {
  const manager = new window.EmployeeManager();
  const searchInput = document.getElementById('searchInput');
  const listContainer = document.getElementById('listContainer');
  const detailModal = document.getElementById('detailModal');
  const detailContent = document.getElementById('detailContent');
  const closeModal = document.getElementById('closeModal');
  const recentList = document.getElementById('recentList');

  function renderList(employees) {
    listContainer.innerHTML = '';
    const fragment = document.createDocumentFragment();
    employees.forEach(emp => {
      const wrapper = document.createElement('div');
      wrapper.innerHTML = manager.renderCardHTML(emp);
      const article = wrapper.firstElementChild;
      article.addEventListener('click', () => showDetail(emp.id));
      article.addEventListener('keypress', (e) => { if (e.key === 'Enter') showDetail(emp.id); });
      fragment.appendChild(article);
    });
    listContainer.appendChild(fragment);
  }

  function showDetail(id) {
    const emp = manager.getById(id);
    if (!emp) return;
    detailContent.innerHTML = `<h2>${emp.name}</h2><p><strong>${emp.role}</strong> — ${emp.department}</p><p>Email: ${emp.email || '-'}<br/>Phone: ${emp.phone || '-'}</p>`;
    detailModal.classList.remove('hidden');
    const ev = new CustomEvent('employee:selected', { detail: emp });
    window.dispatchEvent(ev);
  }

  function hideDetail() {
    detailModal.classList.add('hidden');
  }

  
  let searchTimer = null;
  searchInput.addEventListener('input', () => {
    clearTimeout(searchTimer);
    searchTimer = setTimeout(() => {
      const q = searchInput.value;
      const filtered = manager.filter(q);
      renderList(filtered);
    }, 200);
  });

  closeModal.addEventListener('click', hideDetail);
  detailModal.addEventListener('click', (e) => { if (e.target === detailModal) hideDetail(); });

  manager.loadData(700).then((data) => {
    renderList(data);
  });
})();
