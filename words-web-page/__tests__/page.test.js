import '@testing-library/jest-dom'
import { render, fireEvent, waitFor, screen } from '@testing-library/react';
import NumberToText from '@/app/components/numbertotext'
 
describe('NumberToText', () => {
    it('updates test when a number is entered and button is clicked', async () => {
        render(<NumberToText />);
    
        const input = screen.getByAltText("numberinput");
        const translateButton = screen.getByText('Translate');
        fireEvent.change(input, { target: { value: 123 } });
        fireEvent.click(translateButton);
    
        await waitFor(() =>
          expect(screen.getByText('Your Translation is: "one hundred and twenty three dollars"')).toBeInTheDocument()
        );
      });
})