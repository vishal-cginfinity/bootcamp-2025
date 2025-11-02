import { render, screen } from '@testing-library/react';
import App from './App';
 
test('renders the main app heading', () => {

  render(<App />);

  const mainHeading = screen.getByRole('heading', { name: /Taskify/i });
  
  expect(mainHeading).toBeInTheDocument();
});