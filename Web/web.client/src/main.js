import { createApp } from 'vue';
import App from './App.vue'
import components from '@/components/UI'
import router from "@/router/router.js";

import * as monaco from "monaco-editor"
import editorWorker from "monaco-editor/esm/vs/editor/editor.worker?worker"
import jsonWorker from "monaco-editor/esm/vs/language/json/json.worker?worker"
import cssWorker from "monaco-editor/esm/vs/language/css/css.worker?worker"
import htmlWorker from "monaco-editor/esm/vs/language/html/html.worker?worker"
import tsWorker from "monaco-editor/esm/vs/language/typescript/ts.worker?worker"
import { loader } from "@guolao/vue-monaco-editor"

const app = createApp(App);

self.MonacoEnvironment = {
	getWorker(_, label) {
		if (label === "json") {
			return new jsonWorker()
		}
		if (label === "css" || label === "scss" || label === "less") {
			return new cssWorker()
		}
		if (label === "html" || label === "handlebars" || label === "razor") {
			return new htmlWorker()
		}
		if (label === "typescript" || label === "javascript") {
			return new tsWorker()
		}
		return new editorWorker()
	}
};

loader.config({ monaco })

components.forEach(component => {
	app.component(component.name, component);
});

app.use(router)
	.mount('#app');

