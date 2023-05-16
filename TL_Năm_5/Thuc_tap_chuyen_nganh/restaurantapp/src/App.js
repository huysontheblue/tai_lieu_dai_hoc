import { Routes, Route } from "react-router-dom";
import Header from "./components/Header";
import Maincontainer from "./components/Maincontainer";
import Createcontainer from "./components/Createcontainer";
import { AnimatePresence } from "framer-motion";

function App() {
  return (
    <AnimatePresence>
      <div className="w-screen h-auto flex flex-col bg-primary">
        <Header />
        <main className="mt-14 sm:pt-10 md:mt-20 px-8 py-4 w-full">
          <Routes>
            <Route path="/*" element={<Maincontainer/>}/>
            <Route path="/createItem" element={<Createcontainer/>}/>
          </Routes>
        </main>
      </div>
    </AnimatePresence>
  );
}

export default App;
