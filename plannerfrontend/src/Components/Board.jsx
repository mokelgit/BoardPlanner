import Card from './Card'
import Column from './Column'

export default function Board(){
    return(
        <div className="border-[1px] border-solid border-black w-[90%] m-auto mt-2">
            <div className="flex h-[28px] border-[1px] border-solid border-b-black bg-green-200 w-full">
                <div>
                    <h1 className='font-bold'>New Board</h1>
                </div>
            </div>
            <div className='flex'>
                <Column />
                <Column />
                <Column />
            </div>


        </div>
    )
}


