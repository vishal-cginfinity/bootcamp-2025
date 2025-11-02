import { useState, useEffect } from 'react';
import TaskForm from './components/TaskForm';
import TaskList from './components/TaskList';
import Footer from './components/Footer';
import './App.css';

function App() {
  const [tasks, setTasks] = useState(() => {
    const savedTasks = localStorage.getItem('tasks');
    return savedTasks ? JSON.parse(savedTasks) : [];
  });

  const [filter, setFilter] = useState('all');

  useEffect(() => {
    localStorage.setItem('tasks', JSON.stringify(tasks));
  }, [tasks]);

  const addTask = (text) => {
    const newTask = {
      id: Date.now(),
      text: text,
      completed: false,
    };
    setTasks([...tasks, newTask]);
  };

  const toggleTaskComplete = (taskId) => {
    setTasks(
      tasks.map((task) =>
        task.id === taskId ? { ...task, completed: !task.completed } : task
      )
    );
  };

  const deleteTask = (taskId) => {
    setTasks(tasks.filter((task) => task.id !== taskId));
  };

  const clearCompletedTasks = () => {
    setTasks(tasks.filter((task) => !task.completed));
  };

  const activeTaskCount = tasks.filter((task) => !task.completed).length;

  const filteredTasks = tasks.filter((task) => {
    if (filter === 'active') {
      return !task.completed;
    }
    if (filter === 'completed') {
      return task.completed;
    }
    return true;
  });

  const completedTaskCount = tasks.length - activeTaskCount;

  return (
    <div className="app">
      <h1>Taskify</h1>

      <TaskForm onAddTask={addTask} />

      <TaskList
        tasks={filteredTasks}
        onToggleComplete={toggleTaskComplete}
        onDeleteTask={deleteTask}
      />

      {tasks.length > 0 && (
        <Footer
          activeTaskCount={activeTaskCount}
          completedTaskCount={completedTaskCount}
          filter={filter}
          onSetFilter={setFilter}
          onClearCompleted={clearCompletedTasks}
        />
      )}
    </div>
  );
}

export default App;