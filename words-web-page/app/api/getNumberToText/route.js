import { NextResponse } from "next/server";

export async function GET(req) {
    try {
      const number = req.nextUrl.searchParams.get("number");
      const res = await fetch(`http://localhost:5261/numberToText/$${number}`, {
        method: 'GET',
        headers: {
          'accept': 'text/plain',
        },
      });

      const data = await res.json();
      return NextResponse.json(data);
    } catch {
      return new NextResponse(null, {
        status: 500,
        statusText: 'error',
      });
  
    }
    
    
} 