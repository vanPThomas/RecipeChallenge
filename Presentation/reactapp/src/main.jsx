import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.jsx";
import "./index.css";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import MainPageJury from "./MainPageJury.jsx";
import MainPageBeheer from "./MainPageBeheer.jsx";
import RootLayout from "./RootLayout/RootLayout.jsx";
import MainPageRecipe from "./MainPageRecipe.jsx";
import CreateRecipePage2 from "./CreateRecipeDisplay/CreateRecipePage2/CreateRecipePage2.jsx";
import CreateRecipePage3 from "./CreateRecipeDisplay/CreateRecipePage3/CreateRecipePage3.jsx";
import CreateRecipePage4 from "./CreateRecipeDisplay/CreateRecipePage4/CreateRecipePage4.jsx";
import CreateRecipePage5 from "./CreateRecipeDisplay/CreateRecipePage5/CreateRecipePage5.jsx";
const queryClient = new QueryClient();

const browserRouter = createBrowserRouter([
  {
    path: "/",
    element: <RootLayout />,
    children: [
      {
        path: "/",
        element: <App />,
      },
      {
        path: "/jury",
        element: <MainPageJury />,
      },
      {
        path: "/beheer",
        element: <MainPageBeheer />,
      },
      {
        path: "/recipe",
        element: <MainPageRecipe />,
      },
      {
        path: "/recipe/2",
        element: <CreateRecipePage2 />,
      },
      {
        path: "/recipe/3",
        element: <CreateRecipePage3 />,
      },
      {
        path: "/recipe/4",
        element: <CreateRecipePage4 />,
      },
      {
        path: "/recipe/5",
        element: <CreateRecipePage5 />,
      },
    ],
  },
]);

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <QueryClientProvider client={queryClient}>
      <RouterProvider router={browserRouter} />
    </QueryClientProvider>
  </React.StrictMode>
);
