function TaskItem({ task, onToggleComplete, onDeleteTask }) {
  const itemClassName = `task-item ${task.completed ? 'completed' : ''}`;

  return (
    <li className={itemClassName}>
      <input
        type="checkbox"
        checked={task.completed}
        onChange={() => onToggleComplete(task.id)}
      />
      <span>{task.text}</span>
      <button
        className="delete-btn"
        data-testid="delete-button"
        onClick={() => onDeleteTask(task.id)}
      >
        &times;
      </button>
    </li>
  );
}

export default TaskItem;