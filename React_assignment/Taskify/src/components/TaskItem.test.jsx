import { render, screen, fireEvent } from '@testing-library/react';
import { vi } from 'vitest'; 
import TaskItem from './TaskItem';

const mockTask = {
  id: 1,
  text: 'Test this task',
  completed: false,
};
 

describe('TaskItem component', () => {
 
  test('renders the task text correctly', () => {

    render(
      <TaskItem 
        task={mockTask} 
        onDelete={() => {}} 
        onToggleComplete={() => {}} 
      />
    );
 

    expect(screen.getByText('Test this task')).toBeInTheDocument();
  });
 
  test('calls onDelete prop when the delete button is clicked', () => {
    const mockDelete = vi.fn(); 
    
    render(
      <TaskItem 
        task={mockTask} 
        onDelete={mockDelete}
        onToggleComplete={() => {}} 
      />
    );

    const deleteButton = screen.getByTestId('delete-button');

    fireEvent.click(deleteButton);
 
    expect(mockDelete).toHaveBeenCalledTimes(1);
  });
 
  test('calls onToggleComplete prop when the checkbox is clicked', () => {
    const mockToggle = vi.fn();
 
    render(
      <TaskItem 
        task={mockTask} 
        onDelete={() => {}}
        onToggleComplete={mockToggle}
      />
    );

    const checkbox = screen.getByRole('checkbox');
 
    fireEvent.click(checkbox);

    expect(mockToggle).toHaveBeenCalledTimes(1);
  });
 
});