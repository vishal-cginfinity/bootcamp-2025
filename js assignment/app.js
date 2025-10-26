(function () {
    function EmployeeManager(initial) {
        if (initial === void 0) { initial = []; }
        this.employees = initial;
    }
    EmployeeManager.prototype.loadData = function (delay) {
        var _this = this;
        if (delay === void 0) { delay = 600; }
        return new Promise(function (resolve) {
            setTimeout(function () {
                if (_this.employees.length === 0) {
                    _this.employees = _this.defaultData();
                }
                resolve(_this.employees);
            }, delay);
        });
    };
    EmployeeManager.prototype.defaultData = function () {
        return [
            { id: 1, name: 'Nitin', role: 'Frontend Engineer', department: 'Engineering', email: 'alice@example.com', phone: '555-0100' },
            { id: 2, name: 'Sumit', role: 'Product Manager', department: 'Product', email: 'bob@example.com', phone: '555-0101' },
            { id: 3, name: 'Harsh', role: 'UX Designer', department: 'Design', email: 'carmen@example.com', phone: '555-0102' },
            { id: 4, name: 'Yash', role: 'Backend Engineer', department: 'Engineering', email: 'daniel@example.com', phone: '555-0103' },
            { id: 5, name: 'Anshuman', role: 'Data Scientist', department: 'Data', email: 'eva@example.com', phone: '555-0104' }
        ];
    };
    EmployeeManager.prototype.filter = function (keyword) {
        var q = (keyword || '').trim().toLowerCase();
        if (!q)
            return this.employees.slice();
        return this.employees.filter(function (e) { return (e.name.toLowerCase().includes(q) || e.role.toLowerCase().includes(q) || e.department.toLowerCase().includes(q)); });
    };
    EmployeeManager.prototype.getById = function (id) {
        return this.employees.find(function (e) { return e.id === id; });
    };
    EmployeeManager.prototype.renderCardHTML = function (e) {
        return "\n      <article class=\"card\" data-id=\"" + e.id + "\" tabindex=\"0\">\n        <h4>" + e.name + "</h4>\n        <p>" + e.role + " — <small>" + e.department + "</small></p>\n      </article>\n    ";
    };
    window.EmployeeManager = EmployeeManager;
})();
