import React from 'react'
import Delivery from "../img/delivery.png"
import HeroBg from "../img/heroBg.png";
import { heroData } from '../utils/data';


const HomeContainer = () => {
  return (
    <section className='grid grid-cols-1 md:grid-cols-2 gap-2 w-full overflow-y-hidden mt-8 lg:mt-0' id="home">
      <div className='flex-1 flex flex-col items-start justify-center gap-6'>
        <div className='flex items-center gap-2 justify-center bg-orange-200 px-4 py-1 rounded-full'>
          <p className='text-base text-orange-500 font-semibold'>
            Bike Delivery
          </p>
          <div className='w-8 h-8 bg-white rounded-full overflow-hidden'>
            <img 
              src={Delivery} 
              className="w-full h-full object-contain" 
              alt="Bike" 
            />
          </div>
        </div>

        <p className='text-[2.5rem] lg:text-[4.5rem] font-bold tracking-wide text-headingColor'>
          The Fastest Delevery in 
          <span className='text-orange-600 text-[3rem] lg:text-[5rem]'>
            Your city
          </span>
        </p>

        <p className='text-base text-textColor md:text-left md:w-[80%]'>
          Aside from their natural good taste and freat crunchy, texture
          alongside wonderfull colors and fragnances, eating a large serving of
          fresh.
        </p>

        <button 
          type='button'  
          className='bg-gradient-to-br from-orange-400 to-orange-500 w-full px-4 py-2 rounded-lg hover:shadow-lg transition-all ease-in-out duration-100 md:w-auto'
        >
          Order Now
        </button>

      </div>
      <div className='py-2 flex-1 flex items-center relative'>
        <img 
          src={HeroBg} 
          className='lg:h-620 lg:w-auto h-1000 w-full ml-auto' 
          alt="Hero" />

        <div className='w-full h-full top-0 left-0 absolute flex items-center justify-center px-36 pt-8 gap-4 flex-wrap'>
            {heroData && heroData.map(n =>(
              <div key={n.id} 
                className='w-190 p-4 bg-slate-200 backdrop-blur-md rounded-3xl flex items-center 
                  justify-center flex-col min-w-[190px] drop-shadow-xl px-10'>
                <img src={n.imageSrc} 
                  className='w-40 -mt-24'
                  alt="Icream" />
                <p className='text-xl font-semibold text-textColor mt-4'>
                  {n.name}
                </p>
                <p className='text-sm text-lighttextGray font-semibold my-3'>
                  {n.decp}
                </p>
                <p className='text-sm font-semibold text-headingColor'>
                  <span className='text-xs text-red-400'>$</span> {n.price}
                </p>
              </div>
            ))}
        </div>
      </div>
    </section>
  )
}

export default HomeContainer