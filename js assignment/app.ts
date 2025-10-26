interface Employee {
  id: number;
  name: string;
  role: string;
  department: string;
  email?: string;
  phone?: string;
  avatarUrl?: string;
}

class EmployeeManager {
  private employees: Employee[] = [];
  constructor(initial: Employee[] = []) {
    this.employees = initial;
  }


  loadData(delay = 600): Promise<Employee[]> {
    return new Promise((resolve) => {
      setTimeout(() => {
        if (this.employees.length === 0) {
          this.employees = this.defaultData();
        }
        resolve(this.employees);
      }, delay);
    });
  }

  defaultData(): Employee[] {
    return [
      { id: 1, name: 'Nitin', role: 'Frontend Engineer', department: 'Engineering', email: 'alice@example.com', phone: '555-0100' },
      { id: 2, name: 'Sumit', role: 'Product Manager', department: 'Product', email: 'bob@example.com', phone: '555-0101' },
      { id: 3, name: 'Harsh', role: 'UX Designer', department: 'Design', email: 'carmen@example.com', phone: '555-0102' },
      { id: 4, name: 'Yash', role: 'Backend Engineer', department: 'Engineering', email: 'daniel@example.com', phone: '555-0103' },
      { id: 5, name: 'Anshuman', role: 'Data Scientist', department: 'Data', email: 'eva@example.com', phone: '555-0104' }
    ];
  }


  filter(keyword: string): Employee[] {
    const q = keyword.trim().toLowerCase();
    if (!q) return this.employees.slice();
    return this.employees.filter(e => (
      e.name.toLowerCase().includes(q) ||
      e.role.toLowerCase().includes(q) ||
      e.department.toLowerCase().includes(q)
    ));
  }

  getById(id: number): Employee | undefined {
    return this.employees.find(e => e.id === id);
  }

  renderCardHTML(e: Employee): string {
    return `
      <article class="card" data-id="${e.id}" tabindex="0">
        <h4>${e.name}</h4>
        <p>${e.role} — <small>${e.department}</small></p>
      </article>
    `;
  }
}


(window as any).EmployeeManager = EmployeeManager;
export { Employee, EmployeeManager };
