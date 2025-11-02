function Footer({
  activeTaskCount,
  completedTaskCount,
  filter,
  onSetFilter,
  onClearCompleted,
}) {
  return (
    <footer className="footer">
      <span className="task-count">
        <strong>{activeTaskCount}</strong> item{activeTaskCount !== 1 ? 's' : ''} left
      </span>

      <ul className="filters">
        <li>
          <button
            className={filter === 'all' ? 'selected' : ''}
            onClick={() => onSetFilter('all')}
          >
            All
          </button>
        </li>
        <li>
          <button
            className={filter === 'active' ? 'selected' : ''}
            onClick={() => onSetFilter('active')}
          >
            Active
          </button>
        </li>
        <li>
          <button
            className={filter === 'completed' ? 'selected' : ''}
            onClick={() => onSetFilter('completed')}
          >
            Completed
          </button>
        </li>
      </ul>

      {completedTaskCount > 0 && (
        <button
          className="clear-completed"
          onClick={onClearCompleted}
        >
          Clear completed
        </button>
      )}
    </footer>
  );
}

export default Footer;