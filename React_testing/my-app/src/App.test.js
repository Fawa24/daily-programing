import { render, screen } from '@testing-library/react';
import App from './App';

test('renders learn react link', () => {
  render(<App />);
  const linkElement = screen.getByText(/Hello world!/i);
  const btnElement = screen.getByRole('button');
  const inptElement = screen.getByPlaceholderText(/input value/i); 
  expect(linkElement).toBeInTheDocument();
  expect(btnElement).toBeInTheDocument();
  expect(inptElement).toBeInTheDocument();
});
