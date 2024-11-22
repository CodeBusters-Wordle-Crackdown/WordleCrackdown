import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

export default defineConfig({
  plugins: [react()],
  publicDir: 'public', // Ensure static files are served from 'public/'
  server: {
    open: true, // Automatically opens the app in the browser
    port: 3000, // Local development server port
  },
  build: {
    outDir: 'dist',
    rollupOptions: {
      input: './index.html', // Main HTML entry point
    },
  },
});
