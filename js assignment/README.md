Employee Directory demo

Files:
- index.html — main page (open in browser)
- styles.css — basic styling
- app.ts — TypeScript source (defines `Employee` and `EmployeeManager`)
- app.js — compiled JS equivalent of `app.ts` (used by the page)
- scripts.js — plain JavaScript: fetch simulation, render, search and click-to-detail
- jquery-script.js — jQuery behaviors: DOM manipulation (.append, .html), events (.on), animations

How to run:
1. Open `index.html` in your browser (no server required).
2. Type in the search box to filter employees.
3. Click a card to view details (modal). jQuery will animate the modal and add the viewed person to "Recently viewed".

Optional (recompile TypeScript):
- If you want to edit `app.ts` and recompile, install TypeScript and run `tsc app.ts --target ES5 --outFile app.js`.

Notes:
- The page includes `app.js` so it runs without building. The TypeScript source is included for reference and typing.
- The example purposely splits responsibilities: TypeScript provides typed data + render strings, `scripts.js` uses vanilla DOM & search logic, and `jquery-script.js` demonstrates jQuery DOM ops and animations.