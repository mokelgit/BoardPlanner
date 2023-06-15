import axios from 'axios';
import Board from './Components/Board'
axios.get('https://localhost:7152/api/User')
  .then(response => {
    // Handle the response data
    console.log(response.data);
  })
  .catch(error => {
    // Handle the error
    console.error(error);
  });

//test
export default function App() {
  return (
    <div className="min-h-screen">
        <div className='flex justify-between'>
            <Board />
        </div>
    </div>
  )
}