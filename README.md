## Getting Started

Application contains a Nextjs frontend and .NET server. Run the backend and then the frontend to test interactievly.

## Hosting backend

First to host and interact with the backend:

```bash
cd words-web-backend
```

then...

```bash
dotnet watch run
```

Open [http://localhost:5261/](http://localhost:5261/) with your browser to interact with the server.

## Hosting frontend

Next host the React Application:

```bash
cd words-web-page
```

then...

```bash
npm run dev
# or
yarn dev
# or
pnpm dev
# or
bun dev
```

Open [http://localhost:3000](http://localhost:3000) with your browser to see the result.

## To run test on api route

```bash
cd words-web-backend.Tests
```

...then

```bash
dotnet watch run
```
