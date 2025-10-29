import { createContext, useReducer } from 'react';

export const ItemContext = createContext();

const reducer = (state, action) => {
  switch (action.type) {
    case 'ADD': return [...state, action.payload];
    case 'REMOVE': return state.filter((_, i) => i !== action.payload);
    default: return state;
  }
};

export const ItemProvider = ({ children }) => {
  const [items, dispatch] = useReducer(reducer, []);
  return (
    <ItemContext.Provider value={{ items, dispatch }}>
      {children}
    </ItemContext.Provider>
  );
};