import React from 'react'
import { useState } from 'react'
import { motion } from 'framer-motion';
import { MdFastfood, MdCloudUpload, MdDelete, MdFoodBank } from "react-icons/md"
import { categories } from '../utils/data';
import Loader from './Loader';

const Createcontainer = () => {
  const [title, setTitle] = useState("");
  const [calories, setCalories] = useState("");
  const [price, setPrice] = useState("");
  const [category, setCategory] = useState(null);
  const [imageAsset, setImageAsset] = useState(null);
  const [fields, setFields] = useState(false);
  const [alertStatus, setAlertStatus] = useState("danger");
  const [msg, setMsg] = useState(null);
  const [isLoading, setIsLoading] = useState(false);

  const uploadImage = () => {};

  const deleteImage = () => {};

  return (
    <div className='w-full h-auto min-h-screen flex items-center justify-center'>
      <div className='w-[90%] md:w-[75%] border border-gray-400 rounded-lg p-4 flex flex-col items-center justify-center'>
        {fields && (
          <motion.p 
            initial={{opacity: 0}}
            animate={{opacity: 1}}
            exit={{opacity: 0}}
            className={`w-full p-2 rounded-lg text-center text-lg font-semibold ${
              alertStatus === 'danger' 
              ? 'bg-red-400 text-red-800' 
              : 'bg-emerald-400 text-emerald-800'}`}
          >
            {msg}
          </motion.p>
        )}

        <div className='w-full py-2 border-gray-300 flex items-center gap-2'>
          <MdFastfood className='text-xl text-gray-700 ' /> 
          <input 
            type="text"  
            required={title} 
            placeholder="Give me a title..." 
            onChange={(e)=>setTitle(e.target.value)}
            className='w-full h-full text-lg bg-transparent 
              outline-none border-none placeholder:text-gray-400
              text-textColor'
          />    
        </div>

        <div className='w-full'>
          <select onChange={(e)=>setCategory(e.target.value)}
            className="outline-none w-full text-base border-b-2 border-gray-200 p-2 rounded-md cursor-pointer"  
          >
            <option value="other" className='bg-white'>
              Select Category
            </option>
            {categories && categories.map(item => (
              <option key={item.id} className="text-base border-0 outline-none capitalize bg-white text-headingColor"
                value={item.urlParamName}
              >
                {item.name}
              </option>
            ))}
          </select>
        </div>

        <div className='group flex justify-center items-center flex-col border-2 
          border-dotted border-gray-300 w-full h-255 
          md:h-420 cursor-pointer rounded-lg mt-4'
        >
          {isLoading ? ( <Loader /> 
            ) : ( <>
              {!imageAsset ?  ( <>
                <label className='w-full h-full flex flex-col items-center justify-center cursor-pointer'>
                  <div className='w-full h-full flex flex-col items-center justify-center gap-2'>
                    <MdCloudUpload className='text-gray-500 text-3xl hover:text-gray-700' />
                    <p className='text-gray-500 hover:text-gray-700'>
                      Click here to upload
                    </p>
                  </div>
                  <input 
                    type="file" 
                    name='uploading' 
                    accept='image/*' 
                    onChange={uploadImage}
                    className="w-0 h-0"
                  />
                </label>
              </> 
            ) : ( 
              <>
                <div className='relative h-full'>
                  <img 
                    rc={imageAsset} 
                    alt="Upload image" 
                    className='w-full h-full object-cover'
                  />
                  <button
                    type='button' 
                    className='absolute bottom-3 right-3 p-3 rounded-full bg-red-500 text-xl cursor-pointer outline-none hover:shadow-md duration-500 transition-all ease-in-out'
                    onClick={deleteImage}
                  >
                    <MdDelete className='text-white' />
                  </button>
                </div>
              </>
              )}
            </>
          )}
        </div>

        <div className='w-full flex flex-col md:flex-row items-center gap-3'>
          <div className='w-full py-2 bottom-b border-gray-300 flex items-center gap-2'>
            <MdFoodBank className='text-gray-700 text-2xl' />
            <input type="text" required placeholder='Calories'
              className='w-full h-full text-lg bg-transparent outline-none border-none placeholder:text-gray-400'
            />
          </div>
        </div>
      </div>
    </div>
  );
};

export default Createcontainer